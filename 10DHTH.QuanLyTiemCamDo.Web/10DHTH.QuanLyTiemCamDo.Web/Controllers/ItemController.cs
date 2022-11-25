using _10DHTH.QuanLyTiemCamDo.DataAccess.Commons;
using _10DHTH.QuanLyTiemCamDo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace _10DHTH.QuanLyTiemCamDo.Web.Controllers
{

    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itmehService)
        {
            _itemService = itmehService;
        }
        [Route("~/index")]
        [HttpGet]
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 4)
        {

            ViewData["type"] = await _itemService.GetAllCategoryAsync();
            var pageRequest = new PagingRequestBase() { PageIndex = pageIndex, PageSize = pageSize };

            var users = await _itemService.GetPagingItems(pageRequest);

            return View(users);
        }
        [Route("~/detail")]
        [HttpGet]
        public async Task<IActionResult> DetailItem(int IdItem)
        {
            var result = await _itemService.DetailsItem(IdItem);
            ////ViewBag.maloaisach = result.MaLoai;
            return View(result);
            
        }
    }
}
