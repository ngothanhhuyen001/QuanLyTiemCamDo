using System;
using System.Collections.Generic;
using System.Text;

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Commons
{
    public class ApiResult<T>
    {
        public string Message { get; set; } = null!;
        public int Code { get; set; }
        public T Data { get; set; }

    }
}
