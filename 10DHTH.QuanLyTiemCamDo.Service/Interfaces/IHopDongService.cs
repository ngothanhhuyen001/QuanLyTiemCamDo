using _10DHTH.QuanLyTiemCamDo.DataAccess.Models;
using _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _10DHTH.QuanLyTiemCamDo.Service.Interfaces
{
    public interface IHopDongService
	{
        /// <summary>
        /// get list hop dong
        /// </summary>
        /// <returns></returns>
        Task<List<HopDongInput>> GetAll();
        /// <summary>
        /// Tao Hop Dong
        /// </summary>
        /// <param name="productType"></param>
        /// <returns></returns>
        Task<HopDong> CreateAsync(HopDong hdinput);
        /// <summary>
        /// Update Hop dong
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productResult"></param>
        /// <returns></returns>
        Task<HopDong> UpdateAsync(int id, HopDongInput productResult);
    }
}
