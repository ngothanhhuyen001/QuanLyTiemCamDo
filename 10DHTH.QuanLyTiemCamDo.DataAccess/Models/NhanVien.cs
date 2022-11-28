using System;
using System.Collections.Generic;

#nullable disable

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
            HopDongs = new HashSet<HopDong>();
            RefreshTokens = new HashSet<RefreshToken>();
        }

        public int MaNv { get; set; }
        public string TenNv { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Cmmn { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public byte[] Mkhash { get; set; }
        public byte[] Mksalt { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
        public virtual ICollection<HopDong> HopDongs { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
