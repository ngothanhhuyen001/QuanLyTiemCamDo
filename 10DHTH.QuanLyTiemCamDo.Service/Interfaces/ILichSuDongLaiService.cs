using _10DHTH.QuanLyTiemCamDo.DataAccess.Models;
using _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _10DHTH.QuanLyTiemCamDo.Service.Interfaces
{
	public interface ILichSuDongLaiService
	{
        /// <summary>
        /// Lich su dong lai theo hoa don 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<LichSuDongLai> GetByIdLichSuDongLai(int id);
        /// <summary>
        /// update lich su dong lai
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<LichSuDongLai> UpdateItem(int id, LichSuDongLai item);
    }
}
