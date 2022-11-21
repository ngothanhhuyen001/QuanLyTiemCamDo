﻿using System;
using System.Collections.Generic;

#nullable disable

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int IdRole { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}