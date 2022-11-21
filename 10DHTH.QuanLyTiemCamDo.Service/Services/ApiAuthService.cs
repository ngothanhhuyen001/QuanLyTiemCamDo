using _10DHTH.QuanLyTiemCamDo.DataAccess.Commons;
using _10DHTH.QuanLyTiemCamDo.DataAccess.Models;
using _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels;
using _10DHTH.QuanLyTiemCamDo.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _10DHTH.QuanLyTiemCamDo.Service.Services
{
    public class ApiAuthService : IApiAuthService
    {
        private readonly QuanLyTiemCamDoContext _context;
        private readonly IConfiguration _configuration;
        
        public ApiAuthService(QuanLyTiemCamDoContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }

        public ApiResult<LoginResponse> Login(LoginRequest user)
        {
            var userDB = _context.Users.Where(t => t.Email.Equals(user.Email)).FirstOrDefault();
            if (userDB == null)
            {
                return new ApiResult<LoginResponse>
                {
                    Code = 404,
                    Message = "Email does not exist!",
                };
            }
            else
            {
                if (VerifyPasswordHash(user.Password, userDB.PasswordHash, userDB.PasswordSalt))
                {
                    var token = CreateToken(userDB.IdUser);
                    var refreshToken = GenerateRefreshToken(userDB.IdUser);

                    _context.RefreshTokens.Add(refreshToken);
                    _context.SaveChanges();
                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                        Expires = refreshToken.Expires
                    };
                    return new ApiResult<LoginResponse>
                    {
                        Code = 200,
                        Data = new LoginResponse
                        {
                            Token = token,
                            RefreshToken = refreshToken.Token,
                            Email = userDB.Email
                        },
                        Message = "Login Success!",
                    };
                }
                return new ApiResult<LoginResponse>
                {
                    Code = 401,
                    Message = "Incorrect password!",
                };
            }
        }
        public async Task<ApiResult<object>> Register(LoginRequest userRequest)
        {
            var userDB = _context.Users.Where(t => t.Email.Equals(userRequest.Email)).FirstOrDefault();
            if (userDB != null)
                return new ApiResult<object>()
                {
                    Code = 200,
                    Message = "Email already exists!",
                };

            CreatePasswordHash(userRequest.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User()
            {
                Email = userRequest.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new ApiResult<object>()
            {
                Code = 200,
                Message = "Sign Up Success!",
                Data = new
                {
                    Email = user.Email
                }
            };
        }
        public async Task<ApiResult<object>> Logout(string refreshToken)
        {

            if (refreshToken == null)
            {
                return new ApiResult<object>
                {
                    Code = 401,
                    Message = "Unauthorized",
                };
            }

            var refreshTokenDB =
                await _context.RefreshTokens
                        .Where(r => r.Token.Equals(refreshToken))
                        .FirstOrDefaultAsync();

            if (refreshTokenDB != null)
            {
                int id = refreshTokenDB.Id;

                //Remove Token old
                _context.RefreshTokens.Remove(refreshTokenDB);
                await _context.SaveChangesAsync();

                return new ApiResult<object>
                {
                    Code = 200,
                    Message = "Logout successful",
                };
            }
            else
            {
                return new ApiResult<object>
                {
                    Code = 403,
                    Message = "Forbidden",
                };
            }
        }
        #region Token
        public string CreateToken(int userId)
        {
            List<Claim> claims = claimsRoles(userId);

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));
           
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddSeconds(60),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public List<Claim> claimsRoles(int userId)
        {
            List<Claim> claims = new List<Claim>();

            var roles = _context.Users.Where(t => t.IdUser == userId).Include(t => t.IdRoleNavigation).ToList();

            if (roles != null)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.IdRoleNavigation.Name));
                }
            }
            claims.Add(new Claim(ClaimTypes.Name, "_UHAIHSA002"));
            return claims;
        }

        public async Task<ApiResult<LoginResponse>> RefreshToken(string refreshToken)
        {
            if (refreshToken == null)
            {
                return new ApiResult<LoginResponse>
                {
                    Code = 401,
                    Message = "Unauthorized",
                };
            }

            var refreshTokenDB =
                await _context.RefreshTokens
                        .Where(r => r.Token.Equals(refreshToken))
                        .FirstOrDefaultAsync();

            if (refreshTokenDB != null)
            {
                int id = refreshTokenDB.Id;

                //Remove Token old
                _context.RefreshTokens.Remove(refreshTokenDB);
                await _context.SaveChangesAsync();

                //Create Token
                string newToken = CreateToken((int)refreshTokenDB.IdUser);

                //GenerateRefreshToken
                var generateRefreshToken = GenerateRefreshToken((int)refreshTokenDB.IdUser);

                //Save token in db
                await SaveRefreshToken(generateRefreshToken);

                //Create Cookie Option
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = generateRefreshToken.Expires
                };

                return new ApiResult<LoginResponse>
                {
                    Code = 200,
                    Data = new LoginResponse
                    {
                        Token = newToken,
                        RefreshToken = generateRefreshToken.Token,
                    },
                    Message = "Ok",
                };
            }
            else
            {
                return new ApiResult<LoginResponse>
                {
                    Code = 403,
                    Message = "Forbidden",
                };
            }
        }
        public async Task SaveRefreshToken(RefreshToken refreshToken)
        {
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
        }
        public RefreshToken GenerateRefreshToken(int userId)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                var refreshToken = new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.Now.AddDays(7),
                    Created = DateTime.Now,
                    IdUser = userId
                };
                return refreshToken;
            }
        }
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        #endregion
    }
}
