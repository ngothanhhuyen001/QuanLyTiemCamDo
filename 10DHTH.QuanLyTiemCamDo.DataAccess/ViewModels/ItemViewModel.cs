using System;
using System.Collections.Generic;
using System.Text;

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels
{
	public class ItemViewModel
	{
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
    }
}
