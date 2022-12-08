using _10DHTH.QuanLyTiemCamDo.DataAccess.Enum;
using _10DHTH.QuanLyTiemCamDo.DataAccess.Models;
using _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels;
using _10DHTH.QuanLyTiemCamDo.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10DHTH.QuanLyTiemCamDo.Service.Services
{
    public class HopDongService : IHopDongService
    {
        private readonly QuanLyTiemCamDoContext _context;

        public HopDongService(QuanLyTiemCamDoContext context)
        {
            _context = context;
        }

       
        public async Task<List<HopDongInput>> GetAll()
        {
            var items = await _context.HopDongs.Include(t => t.MaKhNavigation)
                .Include(t => t.MaNvNavigation)
                .Include(t => t.MaTaiSanNavigation)
                .Include(t => t.MaHtlNavigation)
                .Include(t => t.MaTrangThaiNavigation)
                .Where(t=>t.MaTrangThai != 0 )
                .Select(t => new HopDongInput
                {
                    MaHopDong = t.MaHopDong,
                    TenKh = t.MaKhNavigation.TenKh,
                    TenNv = t.MaNvNavigation.TenNv,
                    TenTaiSan = t.MaTaiSanNavigation.TenTaiSan,
                    TenHinhThuc = t.MaHtlNavigation.TenHinhThuc,
                    NgayLap = t.NgayLap,
                    ThoiGianCam = t.ThoiGianCam,
                    NgayKt = t.NgayKt,
                    SoTienCam = t.SoTienCam,
                    TiLeLai = t.TiLeLai,
                    TenTrangThai = t.MaTrangThaiNavigation.TenTrangThai,
                }).ToListAsync();
            if (items != null)
            {
                return items;
            }
            else
                throw new Exception("Null");
        }
        public async Task<HopDong> CreateAsync(HopDong hdinput)
        {
            var hopdong = new HopDong
            {
                MaKh = hdinput.MaKh,
                MaNv =hdinput.MaNv,
                MaTaiSan = hdinput.MaTaiSan,
                MaHtl = hdinput.MaHtl,
                NgayLap = hdinput.NgayLap,
                ThoiGianCam = hdinput.ThoiGianCam,
                NgayKt = hdinput.NgayKt,
                SoTienCam = hdinput.SoTienCam,
                TiLeLai = hdinput.TiLeLai,
                MaTrangThai = hdinput.MaTrangThai,
            };
            await _context.HopDongs.AddAsync(hopdong);
            await _context.SaveChangesAsync();
            return hopdong;
        }

        public Task<HopDong> UpdateAsync(int id, HopDongInput productResult)
        {
            throw new NotImplementedException();
        }
    }
}
