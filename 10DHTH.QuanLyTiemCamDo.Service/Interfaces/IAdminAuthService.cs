using _10DHTH.QuanLyTiemCamDo.DataAccess.Commons;
using _10DHTH.QuanLyTiemCamDo.DataAccess.Models;
using _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _10DHTH.QuanLyTiemCamDo.Service.Interfaces
{
    public interface IAdminAuthService
    {
        Task<ResultObject<object>> Register(AdminRegisterRequest user);
        ResultObject<AdminLoginResponse> Login(AdminLoginRequest user);
        Task<ResultObject<object>> Logout(string refreshToken);
        Task<ResultObject<AdminLoginResponse>> RefreshToken(string refreshTokenStr);
        string CreateToken(int userId);
        RefreshToken GenerateRefreshToken(int userId);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
