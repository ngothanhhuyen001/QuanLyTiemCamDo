using System;
using System.Collections.Generic;
using System.Text;

namespace _10DHTH.QuanLyTiemCamDo.DataAccess.Commons
{
	public class MyResponseList<T>
	{
        public string Message { get; set; }
        public int Code { get; set; }
        public List<T> Data { get; set; }
    }
}
