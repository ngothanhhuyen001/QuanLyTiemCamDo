using System;
using System.Collections.Generic;

#nullable disable

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Models
{
    public partial class LichSuDongLai
    {
        public int MaLichSu { get; set; }
        public int? MaHopDong { get; set; }
        public DateTime? NgayDongLai { get; set; }
        public double? SoTienLai { get; set; }
        public double? TienDv { get; set; }
        public double? TongTien { get; set; }
        public int? MaTrangThai { get; set; }

        public virtual HopDong MaHopDongNavigation { get; set; }
        public virtual TrangThai MaTrangThaiNavigation { get; set; }
    }
}
