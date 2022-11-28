using System;
using System.Collections.Generic;

#nullable disable

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Models
{
    public partial class Cthd
    {
        public int MaHoaDon { get; set; }
        public int MaTaiSan { get; set; }
        public double? GiaBan { get; set; }

        public virtual HoaDon MaHoaDonNavigation { get; set; }
        public virtual TaiSan MaTaiSanNavigation { get; set; }
    }
}
