using _10DHTH.QuanLyTiemCamDo.DataAccess.Commons;
using _10DHTH.QuanLyTiemCamDo.DataAccess.Models;
using _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels;
using _10DHTH.QuanLyTiemCamDo.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _10DHTH.QuanLyTiemCamDo.Service.Services
{
    public class ItemService : IItemService
    {

        private readonly QuanLyTiemCamDoContext _context;

        public ItemService(QuanLyTiemCamDoContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<Item>> GetPagingItems(PagingRequestBase request)
        {
            int totalRow = await _context.Items.CountAsync();

            var items = await _context.Items.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).ToListAsync();
            var pagedResult = new PagedResult<Item>()
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
        public async Task<MyResponseList<Item>> GetItemByIdTypeAsync(int id)
        {
            var type = await _context.Items.Where(x=>x.IdType==id).ToListAsync();
            return new MyResponseList<Item>
            {
                Data =type,
                Message = "ok",
                Code = 200,
            };
        }
        public async Task<MyResponseList<Item>> SearchItemAsync(string name)
        {
            var result = await _context.Items.Where(t => t.Name.Contains(name)).ToListAsync();
            return new MyResponseList<Item>
            {
                Data = result,
                Message = "ok",
                Code = 200,
            };
        }
        public async Task<ApiResult<Item>> DetailsItem(int id)
        {
            var result = await _context.Items.FindAsync(id);
            if(result==null)
            {
                return new ApiResult<Item>
                {
                    Code = 404,
                    Message = "Item is not exits",
                };
            }   
            return new ApiResult<Item>
            {
                Data = result,
                Message = "ok",
                Code = 200,
            };
        }
    }
}

