using _10DHTH.QuanLyTiemCamDo.DataAccess.Models;
using _10DHTH.QuanLyTiemCamDo.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _10DHTH.QuanLyTiemCamDo.Service.Services
{
    public class LichSuDongLaiService : ILichSuDongLaiService
    {
        private readonly QuanLyTiemCamDoContext _context;

        public LichSuDongLaiService(QuanLyTiemCamDoContext context)
        {
            _context = context;
        }

        public Task<LichSuDongLai> GetByIdLichSuDongLai(int id)
        {
            throw new NotImplementedException();
        }

        public Task<LichSuDongLai> UpdateItem(int id, LichSuDongLai item)
        {
            throw new NotImplementedException();
        }
    }
}
