using _10DHTH.QuanLyTiemCamDo.DataAccess.Commons;
using _10DHTH.QuanLyTiemCamDo.DataAccess.Models;
using _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _10DHTH.QuanLyTiemCamDo.Service.Interfaces
{
    public interface IItemService
    {
        /// <summary>
        /// Get All Item
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PagedResult<TaiSan>> GetPagingItems(PagingRequestBase request);
        /// <summary>
        /// Get All Type
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<List<TypeViewModel>> GetAllCategoryAsync();

        /// <summary>
        /// Get Type  by id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ResultList<TaiSan>> GetItemByIdTypeAsync(int id);
        /// <summary>
        /// Search
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ResultList<TaiSan>> SearchItemAsync(string name);
        /// <summary>
        /// Details Items
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ResultObject<TaiSan>> DetailsItemAsync(int id);

    }
}
