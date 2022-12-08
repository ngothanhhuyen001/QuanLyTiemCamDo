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
    public class NhanVienService : INhanVienService
    {
        private readonly QuanLyTiemCamDoContext _context;

        public NhanVienService(QuanLyTiemCamDoContext context)
        {
            _context = context;
        }
        public async Task<NhanVien> CreateAsync(NhanVien nhanVien)
        {
            var nv = new NhanVien
            {
                MaNv = nhanVien.MaNv,
                TenNv = nhanVien.TenNv,
                Email = nhanVien.Email,
                Sdt = nhanVien.Sdt,
                NgaySinh = nhanVien.NgaySinh,
                Cmmn = nhanVien.Cmmn,
                DiaChi = nhanVien.DiaChi,
                Mkhash = null,
                Mksalt = null,

            };
            await _context.NhanViens.AddAsync(nv);
            await _context.SaveChangesAsync();
            return nv;
        }

        public async Task<List<NhanVien>> GetAllNhanVien()
        {
            var items = await _context.NhanViens.ToListAsync();
            if (items != null)
            {
                return items;
            }
            else
                throw new Exception("Null");
        }

        public async Task<NhanVien> GetByIdNhanVien(int id)
        {
            var nv = await _context.NhanViens.FindAsync(id);
            if (nv != null)
                return nv;
            else
            {
                throw new Exception("Null");
            }
        }

        public async Task<NhanVien> UpdateAsync(NhanVien nhanVien, int id)
        {
            var nv = await _context.NhanViens.FindAsync(id);
            if (nv != null)
            {
                nv.MaNv = nhanVien.MaNv;
                nv.TenNv = nhanVien.TenNv;
                nv.Email = nhanVien.Email;
                nv.Sdt = nhanVien.Sdt;
                nv.NgaySinh = nhanVien.NgaySinh;
                nv.Cmmn = nhanVien.Cmmn;
                nv.DiaChi = nhanVien.DiaChi;
                nv.Mkhash = null;
                nv.Mksalt = null;
            }
            await _context.SaveChangesAsync();
            return nv;
        }
        public async Task DeleteAsync(int id)
        {
            var user = await _context.NhanViens.Where(t => t.MaNv == id).FirstOrDefaultAsync();
            if (user != null)
            {
                _context.NhanViens.Remove(user);
                await _context.SaveChangesAsync();
            }

        }
    }
}
