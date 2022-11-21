using System;
using System.Collections.Generic;

#nullable disable

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Models
{
    public partial class UsersDept
    {
        public UsersDept()
        {
            Users = new HashSet<User>();
        }

        public int IdDept { get; set; }
        public int? IdUser { get; set; }
        public double? TotalDept { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
