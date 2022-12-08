using _10DHTH.QuanLyTiemCamDo.DataAccess.Models;
using _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _10DHTH.QuanLyTiemCamDo.Service.Interfaces
{
    public interface INguoiDungService
    {
        Task<List<KhachHang>> GetAllKhachHang();
        Task<KhachHang> GetByIdKhachHang(int id);
        Task<KhachHang> CreateAsync(KhachHang khachHang);
        Task<KhachHang> UpdateAsync(KhachHang khachHang, int id);
        Task DeleteAsync(int id);
    }
}
