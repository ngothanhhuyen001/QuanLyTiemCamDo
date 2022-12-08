using Microsoft.AspNetCore.Mvc;

namespace _10DHTH.QuanLyTiemCamDo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        [Route("~/admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
