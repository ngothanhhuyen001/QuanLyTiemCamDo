using System;
using System.Collections.Generic;

#nullable disable

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Models
{
    public partial class DichVu
    {
        public DichVu()
        {
            LoaiTaiSans = new HashSet<LoaiTaiSan>();
        }

        public int MaPhiDv { get; set; }
        public string TenDv { get; set; }
        public double? PhiDv { get; set; }

        public virtual ICollection<LoaiTaiSan> LoaiTaiSans { get; set; }
    }
}
