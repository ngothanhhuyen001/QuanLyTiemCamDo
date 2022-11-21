using _10DHTH.QuanLyTiemCamDo.DataAccess.Commons;
using _10DHTH.QuanLyTiemCamDo.DataAccess.Models;
using _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels;
using _10DHTH.QuanLyTiemCamDo.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10DHTH.QuanLyTiemCamDo.Service.Services
{
    public class ItemService : IItemService
    {

        private readonly QuanLyTiemCamDoContext _context;

        public ItemService(QuanLyTiemCamDoContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<ItemViewModel>> GetPagingItems(PagingRequestBase request)
        {
            int totalRow = await _context.Items.CountAsync();

            var items = await _context.Items.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(x => new ItemViewModel()
            {
               IdItem=x.IdItem,
               Name=x.Name,
               Price=x.Price,
               Img=x.Img,


            }).ToListAsync();

            var pagedResult = new PagedResult<ItemViewModel>()
            {
                Code = 200,
                Message = "Login Success!",
                Items = items,
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
            };
            return pagedResult;

        }


        public async Task<List<TypeViewModel>> GetAllCategoryAsync()
        {
            var type = await _context.Types.Select(x => new TypeViewModel()
            {
             IdType=x.IdType,
             Name=x.Name,
            }).ToListAsync();

            return type;

        }

    }
}

