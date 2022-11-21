using _10DHTH.QuanLyTiemCamDo.DataAccess.Commons;
using _10DHTH.QuanLyTiemCamDo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _10DHTH.QuanLyTiemCamDo.Web.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itmehService)
        {
            _itemService = itmehService;
        }
        //public async Task<IActionResult> Index()
        //{
        //    ViewData["type"] = await _itemService.GetAllCategoryAsync();
        //    return View();
        //}
        [HttpGet]
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 2)
        {

            ViewData["type"] = await _itemService.GetAllCategoryAsync();
            var pageRequest = new PagingRequestBase() { PageIndex = pageIndex, PageSize = pageSize };

            var users = await _itemService.GetPagingItems(pageRequest);

            return View(users);
        }
    }
}
