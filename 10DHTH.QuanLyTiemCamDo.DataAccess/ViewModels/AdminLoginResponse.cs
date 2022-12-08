using System;
using System.Collections.Generic;
using System.Text;

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels
{
    public class AdminLoginResponse
    {
        public string Token { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
        public string Sdt { get; set; } = null!;
    }
}
