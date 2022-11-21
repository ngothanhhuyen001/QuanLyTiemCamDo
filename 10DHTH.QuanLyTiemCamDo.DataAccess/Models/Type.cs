using System;
using System.Collections.Generic;

#nullable disable

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Models
{
    public partial class Type
    {
        public Type()
        {
            Items = new HashSet<Item>();
        }

        public int IdType { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
