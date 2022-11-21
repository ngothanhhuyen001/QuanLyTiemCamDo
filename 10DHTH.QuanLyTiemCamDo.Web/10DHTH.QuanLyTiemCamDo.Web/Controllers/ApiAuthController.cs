using _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels;
using _10DHTH.QuanLyTiemCamDo.Service.Interfaces;
using _10DHTH.QuanLyTiemCamDo.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _10DHTH.QuanLyTiemCamDo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ApiAuthController : Controller
    {
        private readonly IApiAuthService _apiauthService;
        public ApiAuthController(IApiAuthService apiauthService)
        {
            _apiauthService = apiauthService;
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(LoginRequest user)
        {
            var loginService = _apiauthService.Login(user);
            return StatusCode(loginService.Code, loginService);
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(LoginRequest user)
        {
            var registerService = await _apiauthService.Register(user);
            return StatusCode(registerService.Code, registerService);
        }

        [Route("refresh-token")]
        [HttpPost]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshTokenStr = Request.Headers["refreshToken"];
            var refreshTokenService = await _apiauthService.RefreshToken(refreshTokenStr);
            if (refreshTokenService.Code == 200)
                Response.Headers.Add("refreshToken", refreshTokenService.Data.RefreshToken);
            return StatusCode(200, refreshTokenService);
        }

        [Route("logout")]
        //[HttpPost, Authorize]
        public async Task<IActionResult> Logout()
        {
            var refreshTokenStr = Request.Headers["refreshToken"];
            var LogoutService = await _apiauthService.Logout(refreshTokenStr);
            return StatusCode(200, LogoutService);
        }
    }
}

