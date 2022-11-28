using System;
using System.Collections.Generic;

#nullable disable

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Models
{
    public partial class TaiSan
    {
        public TaiSan()
        {
            Cthds = new HashSet<Cthd>();
            HopDongs = new HashSet<HopDong>();
        }

        public int MaTaiSan { get; set; }
        public string TenTaiSan { get; set; }
        public int? MaLoai { get; set; }
        public string Nsx { get; set; }
        public string ThuongHieu { get; set; }
        public string HinhAnh { get; set; }
        public string NoiDung { get; set; }
        public double? GiaBan { get; set; }
        public DateTime? NgayThanhLy { get; set; }
        public int? MaTrangThai { get; set; }

        public virtual LoaiTaiSan MaLoaiNavigation { get; set; }
        public virtual TrangThai MaTrangThaiNavigation { get; set; }
        public virtual ICollection<Cthd> Cthds { get; set; }
        public virtual ICollection<HopDong> HopDongs { get; set; }
    }
}
