using _10DHTH.QuanLyTiemCamDo.DataAccess.Enum;
using System;
using System.Collections.Generic;

#nullable disable

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Models
{
    public partial class TrangThai
    {
        public TrangThai()
        {
            HopDongs = new HashSet<HopDong>();
            LichSuDongLais = new HashSet<LichSuDongLai>();
            TaiSans = new HashSet<TaiSan>();
        }

        public int MaTrangThai { get; set; }
        public string TenTrangThai { get; set; }

        public virtual ICollection<HopDong> HopDongs { get; set; }
        public virtual ICollection<LichSuDongLai> LichSuDongLais { get; set; }
        public virtual ICollection<TaiSan> TaiSans { get; set; }
    }
}
