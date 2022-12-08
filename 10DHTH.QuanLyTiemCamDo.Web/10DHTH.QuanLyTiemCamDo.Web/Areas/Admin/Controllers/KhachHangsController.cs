using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _10DHTH.QuanLyTiemCamDo.DataAccess.Models;
using _10DHTH.QuanLyTiemCamDo.Service.Interfaces;

namespace _10DHTH.QuanLyTiemCamDo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KhachHangsController : Controller
    {
        private readonly INguoiDungService _context;

        public KhachHangsController(INguoiDungService context)
        {
            _context = context;
        }
        [Route("~/admin/NguoiDung")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAllKhachHang());
        }
        [Route("~/admin/NguoiDung/detail")]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var khachHang = await _context.GetByIdKhachHang(id);
           
            return View(khachHang);
        }

        public IActionResult Create()
        {
            return View();
        }

        [Route("~/admin/KhachHangs/create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KhachHang khachHang)
        {
            var result = _context.CreateAsync(khachHang);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var khachHang = await _context.GetByIdKhachHang( id);

            return View(khachHang);
        }

        [Route("~/admin/KhachHangs/edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KhachHang khachHang)
        {

            var result = await _context.UpdateAsync(khachHang, id);
            return View(result);
        }

        // GET: Admin/KhachHangs/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

           var result= await _context.GetByIdKhachHang(id);
            return View(result);
        }

        [Route("~/admin/KhachHangs/delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return Ok(_context.DeleteAsync(id));
        }
    }
}
