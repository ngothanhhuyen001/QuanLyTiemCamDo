using System;
using System.Collections.Generic;

#nullable disable

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            Cthds = new HashSet<Cthd>();
        }

        public int MaHoaDon { get; set; }
        public int? MaKh { get; set; }
        public int? MaNv { get; set; }
        public DateTime? NgayBan { get; set; }
        public double? TongTien { get; set; }

        public virtual KhachHang MaKhNavigation { get; set; }
        public virtual NhanVien MaNvNavigation { get; set; }
        public virtual ICollection<Cthd> Cthds { get; set; }
    }
}
