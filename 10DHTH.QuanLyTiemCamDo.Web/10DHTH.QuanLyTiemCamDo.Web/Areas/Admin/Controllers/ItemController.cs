using _10DHTH.QuanLyTiemCamDo.DataAccess.Commons;
using _10DHTH.QuanLyTiemCamDo.DataAccess.Models;
using _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels;
using _10DHTH.QuanLyTiemCamDo.Service.Interfaces;
using _10DHTH.QuanLyTiemCamDo.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _10DHTH.QuanLyTiemCamDo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itmehService)
        {
            _itemService = itmehService;
        }
        [Route("~/admin/item")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var getall = await _itemService.GetAll();
            return View(getall);

        }
        [Route("~/admin/item/detail")]
        [HttpGet]
        public async Task<IActionResult> DetailItem(int IdItem)
        {
            var result = await _itemService.DetailsItemAsync(IdItem);
            return View(result);

        }

        public async Task<IActionResult> Delete(int id)
        {

            var result = await _itemService.GetByIdItem(id);
            return View(result);
        }

        [Route("~/admin/item/edit/{id}")]
        [HttpPost]
        public async Task<ActionResult> Edit(TaiSan ts, int id)
        {
            var result = await _itemService.UpdateItem(id, ts);
            return View(result);
        }


        //[Route("~/admin/item/{id}")]
        //[HttpDelete]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    await _itemService.DeleteAsync(id);
        //    return View("~/admin/item");
        //}

    }
}
