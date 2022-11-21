using System;
using System.Collections.Generic;

#nullable disable

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Models
{
    public partial class Status
    {
        public Status()
        {
            Items = new HashSet<Item>();
        }

        public int IdStatus { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
