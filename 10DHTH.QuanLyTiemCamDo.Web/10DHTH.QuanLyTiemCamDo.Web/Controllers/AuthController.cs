using _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using _10DHTH.QuanLyTiemCamDo.Web.Helpers.Extensions;
using _10DHTH.QuanLyTiemCamDo.Service.Interfaces;

namespace _10DHTH.QuanLyTiemCamDo.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IApiAuthService _apiAuthService;
        public AuthController(IApiAuthService apiAuthService)
        {
            _apiAuthService = apiAuthService;
        }
        [Route("~/login")]
        [HttpGet]
        public async Task<IActionResult> Login()
        {

            return View();
        }
        [Route("~/login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginRequest user)
        {

            if (ModelState.IsValid)
            {
                var loginService = _apiAuthService.Login(user);
                if (loginService.Code == 200)
                {
                    var userSesstion = new UserSession()
                    {
                        Email = loginService.Data.Email,

                    };
                    HttpContext.Session.Set<UserSession>("_authSession", userSesstion);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //ViewBag.LoginFail = "Error";
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                    return RedirectToAction("Login", "Auth");
                }
            }
            return View();

        }
       [Route("~/logout")]
        public async Task<IActionResult> Logout()
        {
            var refreshTokenStr = Request.Headers["refreshToken"];
            var LogoutService = await _apiAuthService.Logout(refreshTokenStr);
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        [Route("~/register")]
        [HttpGet]
        public async Task<IActionResult> Register()
        {

            return View();
        }
        [Route("~/register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RegisterRequest user)
        {
            if (ModelState.IsValid)
            {
               
            }
            return View();

        }
    }
}









