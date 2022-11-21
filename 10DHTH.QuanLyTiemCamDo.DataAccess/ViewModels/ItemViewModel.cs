using System;
using System.Collections.Generic;
using System.Text;

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels
{
	public class ItemViewModel
	{
        public int IdItem { get; set; }
        public string Name { get; set; }
        public int? IdType { get; set; }
        public string Img { get; set; }
        public double? Price { get; set; }
    }
}
