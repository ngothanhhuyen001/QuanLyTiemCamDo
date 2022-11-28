using System;
using System.Collections.Generic;

#nullable disable

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
            HopDongs = new HashSet<HopDong>();
            RefreshTokens = new HashSet<RefreshToken>();
        }

        public int MaKh { get; set; }
        public string TenKh { get; set; }
        public string Email { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string SoDt { get; set; }
        public string Cmnd { get; set; }
        public string DiaChi { get; set; }
        public byte[] Mkhash { get; set; }
        public byte[] Mksalt { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
        public virtual ICollection<HopDong> HopDongs { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
