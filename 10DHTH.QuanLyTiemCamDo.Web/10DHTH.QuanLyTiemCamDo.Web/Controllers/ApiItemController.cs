using _10DHTH.QuanLyTiemCamDo.DataAccess.Commons;
using _10DHTH.QuanLyTiemCamDo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace _10DHTH.QuanLyTiemCamDo.Web.Controllers
{
    [Route("api/[controller]")]
    public class ApiItemController : Controller
	{
        private readonly IItemService _itemService;
        public ApiItemController(IItemService itmehService)
        {
            _itemService = itmehService;
        }
        [Route("index")]
        [HttpGet]
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 30)
        {
            var pageRequest = new PagingRequestBase() { PageIndex = pageIndex, PageSize = pageSize };

            var items = await _itemService.GetPagingItems(pageRequest);
            return Ok(items);

        }
    }
}
