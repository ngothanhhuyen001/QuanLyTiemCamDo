using System;
using System.Collections.Generic;

#nullable disable

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Models
{
    public partial class RefreshToken
    {
        public int Id { get; set; }
        public int? IdUser { get; set; }
        public string Token { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Expires { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
