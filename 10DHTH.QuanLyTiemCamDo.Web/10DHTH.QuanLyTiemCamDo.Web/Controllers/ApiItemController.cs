using _10DHTH.QuanLyTiemCamDo.DataAccess.Commons;
using _10DHTH.QuanLyTiemCamDo.DataAccess.Models;
using _10DHTH.QuanLyTiemCamDo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _10DHTH.QuanLyTiemCamDo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        // GET: api/ApiItem/GetItemByIdType/5
      
        [HttpGet]
        public async Task<IActionResult> GetItemByIdType(int id)
        {
            var items = await _itemService.GetItemByIdTypeAsync(id);
            return StatusCode(items.Code, items);
        }
        //// GET: api/ApiItem/Search?name="name"
        [Route("search")]
        [HttpGet]
        public async Task<IActionResult> Search(string name)
        {

            var items = await _itemService.SearchItemAsync(name);
            return StatusCode(items.Code, items);
        }

        // GET: api/ApiItem/DetailItem/5
        [Route("DetailItem/{mats:int}")]
        [HttpGet]
        public async Task<IActionResult> DetailItem(int mats)
        {
            var items = await _itemService.DetailsItemAsync(mats);
            return StatusCode(items.Code, items);
        }
    }
}
