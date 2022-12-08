using _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels;
using _10DHTH.QuanLyTiemCamDo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _10DHTH.QuanLyTiemCamDo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
   
        private readonly IAdminAuthService _adminauthService;
        public AuthController(IAdminAuthService adminAuthService)
        {
            _adminauthService = adminAuthService;
        }

        [Route("~/admin/login")]
        [HttpPost]
        public IActionResult Login(AdminLoginRequest user)
        {
            var loginService = _adminauthService.Login(user);
            return StatusCode(loginService.Code, loginService);
        }

        [Route("/admin/register")]
        [HttpPost]
        public async Task<IActionResult> Register(AdminRegisterRequest user)
        {
            var registerService = await _adminauthService.Register(user);
            return StatusCode(registerService.Code, registerService);
        }

        [Route("/admin/refresh-token")]
        [HttpPost]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshTokenStr = Request.Headers["refreshToken"];
            var refreshTokenService = await _adminauthService.RefreshToken(refreshTokenStr);
            if (refreshTokenService.Code == 200)
                Response.Headers.Add("refreshToken", refreshTokenService.Data.RefreshToken);
            return StatusCode(200, refreshTokenService);
        }

        [Route("/admin/logout")]
        //[HttpPost, Authorize]
        public async Task<IActionResult> Logout()
        {
            var refreshTokenStr = Request.Headers["refreshToken"];
            var LogoutService = await _adminauthService.Logout(refreshTokenStr);
            return StatusCode(200, LogoutService);
        }
    }
}
