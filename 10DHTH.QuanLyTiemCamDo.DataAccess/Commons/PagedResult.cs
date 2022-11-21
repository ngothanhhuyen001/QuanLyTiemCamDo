using System;
using System.Collections.Generic;
using System.Text;

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Commons
{
    public class PagedResult<T> : PagedResultBase
    {
        public string Message { get; set; } = null!;
        public int Code { get; set; }
        public List<T> Items { get; set; }
    }
}
