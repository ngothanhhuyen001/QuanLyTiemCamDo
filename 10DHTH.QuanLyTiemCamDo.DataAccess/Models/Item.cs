using System;
using System.Collections.Generic;

#nullable disable

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Models
{
    public partial class Item
    {
        public int IdItem { get; set; }
        public string Name { get; set; }
        public int? IdType { get; set; }
        public double? Price { get; set; }
        public int? Nsx { get; set; }
        public string ThuongHieu { get; set; }
        public string Img { get; set; }
        public string Description { get; set; }
        public int? IdStatus { get; set; }

        public virtual Status IdStatusNavigation { get; set; }
        public virtual Type IdTypeNavigation { get; set; }
    }
}
