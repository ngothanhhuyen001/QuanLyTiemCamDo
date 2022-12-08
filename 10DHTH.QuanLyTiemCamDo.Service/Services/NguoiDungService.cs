using _10DHTH.QuanLyTiemCamDo.DataAccess.Models;
using _10DHTH.QuanLyTiemCamDo.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10DHTH.QuanLyTiemCamDo.Service.Services
{
    public class NguoiDungService : INguoiDungService
    {
        private readonly QuanLyTiemCamDoContext _context;

        public NguoiDungService(QuanLyTiemCamDoContext context)
        {
            _context = context;
        }

        public async Task<KhachHang> CreateAsync(KhachHang khachHang)
        {
            var khachhang = new KhachHang
            {
                MaKh = khachHang.MaKh,
                TenKh = khachHang.TenKh,
                Email = khachHang.Email,
                SoDt = khachHang.SoDt,
                NgaySinh = khachHang.NgaySinh,
                Cmnd = khachHang.Cmnd,
                DiaChi = khachHang.DiaChi,
                Mkhash = null,
                Mksalt = null,

            };
            await _context.KhachHangs.AddAsync(khachhang);
            await _context.SaveChangesAsync();
            return khachHang;
        }

        public async Task DeleteAsync(int id)
        {
            var kh = await _context.KhachHangs.Where(t => t.MaKh == id).FirstOrDefaultAsync();
            if (kh != null)
            {
                _context.KhachHangs.Remove(kh);
                await _context.SaveChangesAsync();
            }

        }
        public async Task<List<KhachHang>> GetAllKhachHang()
        {
            var items = await _context.KhachHangs.ToListAsync();
            if (items != null)
            {
                return items;
            }
            else
                throw new Exception("Null");

        }

        public async Task<KhachHang> GetByIdKhachHang(int id)
        {
            var kh = await _context.KhachHangs.FindAsync(id);
            if (kh != null)
            {
                return kh;
            }
            else
            {
                throw new Exception("Null");
            }
        }

        public async Task<KhachHang> UpdateAsync(KhachHang khachHang, int id)
        {
            var kh = await _context.KhachHangs.FindAsync(id);
            if (kh != null)
            {
                kh.MaKh = khachHang.MaKh;
                kh.TenKh = khachHang.TenKh;
                kh.Email = khachHang.Email;
                kh.SoDt = khachHang.SoDt;
                kh.NgaySinh = khachHang.NgaySinh;
                kh.Cmnd = khachHang.Cmnd;
                kh.DiaChi = khachHang.DiaChi;
                kh.Mkhash = null;
                kh.Mksalt = null;
            }
            await _context.SaveChangesAsync();
            return kh;
        }
    }
}
