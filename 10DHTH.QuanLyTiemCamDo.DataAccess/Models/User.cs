using System;
using System.Collections.Generic;

#nullable disable

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            RefreshTokens = new HashSet<RefreshToken>();
        }

        public int IdUser { get; set; }
        public int? IdDept { get; set; }
        public int? IdRole { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool? Remember { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool? IsActive { get; set; }

        public virtual UsersDept IdDeptNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
