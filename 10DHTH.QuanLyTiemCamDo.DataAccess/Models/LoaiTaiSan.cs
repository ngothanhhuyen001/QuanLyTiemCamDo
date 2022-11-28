using System;
using System.Collections.Generic;

#nullable disable

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Models
{
    public partial class LoaiTaiSan
    {
        public LoaiTaiSan()
        {
            TaiSans = new HashSet<TaiSan>();
        }

        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
        public int? MaPhiDv { get; set; }
        public double? TiLeLaiMin { get; set; }
        public double? TiLeLaiMax { get; set; }

        public virtual DichVu MaPhiDvNavigation { get; set; }
        public virtual ICollection<TaiSan> TaiSans { get; set; }
    }
}
