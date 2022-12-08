using _10DHTH.QuanLyTiemCamDo.DataAccess.Enum;
using System;
using System.Collections.Generic;

#nullable disable

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Models
{
    public partial class HopDong
    {
        public HopDong()
        {
            LichSuDongLais = new HashSet<LichSuDongLai>();
        }

        public int MaHopDong { get; set; }
        public int? MaKh { get; set; }
        public int? MaNv { get; set; }
        public int? MaTaiSan { get; set; }
        public DateTime? NgayLap { get; set; }
        public int? MaHtl { get; set; }
        public int? ThoiGianCam { get; set; }
        public DateTime? NgayKt { get; set; }
        public double? SoTienCam { get; set; }
        public double? TiLeLai { get; set; }
        public int? MaTrangThai { get; set; }

        public virtual HinhThucDongLai MaHtlNavigation { get; set; }
        public virtual KhachHang MaKhNavigation { get; set; }
        public virtual NhanVien MaNvNavigation { get; set; }
        public virtual TaiSan MaTaiSanNavigation { get; set; }
        public virtual TrangThai MaTrangThaiNavigation { get; set; }
        public virtual ICollection<LichSuDongLai> LichSuDongLais { get; set; }
    }
}
