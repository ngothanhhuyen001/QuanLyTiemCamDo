using System;
using System.Collections.Generic;
using System.Text;

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels
{
    public class HopDongInput
    {
        public int MaHopDong { get; set; }
        public string TenKh { get; set; }
        public string TenNv { get; set; }
        public string TenTaiSan { get; set; }
        public DateTime? NgayLap { get; set; }
        public string TenHinhThuc { get; set; }
        public int? ThoiGianCam { get; set; }
        public DateTime? NgayKt { get; set; }
        public double? SoTienCam { get; set; }
        public double? TiLeLai { get; set; }
        public string TenTrangThai { get; set; }
    }
}
