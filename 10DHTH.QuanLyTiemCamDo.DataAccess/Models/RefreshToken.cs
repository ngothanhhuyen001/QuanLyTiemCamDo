using System;
using System.Collections.Generic;

#nullable disable

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Models
{
    public partial class RefreshToken
    {
        public int MaToken { get; set; }
        public int? MaKh { get; set; }
        public int? MaNv { get; set; }
        public string Token { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayHetHan { get; set; }

        public virtual KhachHang MaKhNavigation { get; set; }
        public virtual NhanVien MaNvNavigation { get; set; }
    }
}
