using _10DHTH.QuanLyTiemCamDo.DataAccess.Commons;
using _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _10DHTH.QuanLyTiemCamDo.Service.Interfaces
{
    public interface IItemService
	{
        Task<PagedResult<ItemViewModel>> GetPagingItems(PagingRequestBase request);
        Task<List<TypeViewModel>> GetAllCategoryAsync();
    }
}
