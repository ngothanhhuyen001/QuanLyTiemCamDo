using _10DHTH.QuanLyTiemCamDo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _10DHTH.QuanLyTiemCamDo.Service.Interfaces
{
    public interface INhanVienService
    {
        Task<List<NhanVien>> GetAllNhanVien();
        Task<NhanVien> GetByIdNhanVien(int id);
        Task<NhanVien> CreateAsync(NhanVien nhanVien);
        Task<NhanVien> UpdateAsync(NhanVien nhanVien, int id);
        Task DeleteAsync(int id);
    }
}
