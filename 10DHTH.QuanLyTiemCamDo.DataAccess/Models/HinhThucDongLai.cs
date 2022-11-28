using System;
using System.Collections.Generic;

#nullable disable

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Models
{
    public partial class HinhThucDongLai
    {
        public HinhThucDongLai()
        {
            HopDongs = new HashSet<HopDong>();
        }

        public int MaHtl { get; set; }
        public string TenHinhThuc { get; set; }

        public virtual ICollection<HopDong> HopDongs { get; set; }
    }
}
