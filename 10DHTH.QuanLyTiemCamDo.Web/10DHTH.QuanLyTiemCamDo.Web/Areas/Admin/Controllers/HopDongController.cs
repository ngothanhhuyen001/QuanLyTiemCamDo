using _10DHTH.QuanLyTiemCamDo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _10DHTH.QuanLyTiemCamDo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HopDongController : Controller
    {
        private readonly IHopDongService _hopDongService;
        public HopDongController(IHopDongService hopDongService)
        {
            _hopDongService = hopDongService;
        }
        [Route("~/admin/hopdong/getall")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var result = await _hopDongService.GetAll();
            return View(result);

        }
    }
}
