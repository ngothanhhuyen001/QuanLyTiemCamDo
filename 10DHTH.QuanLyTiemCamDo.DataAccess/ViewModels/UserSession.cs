using System;
using System.Collections.Generic;
using System.Text;

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels
{
	public class UserSession
	{

        public int MaKh { get; set; }
        public string TenKh { get; set; }
        public string Email { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string SoDt { get; set; }
        public string Cmnd { get; set; }
        public string DiaChi { get; set; }
    }

}
