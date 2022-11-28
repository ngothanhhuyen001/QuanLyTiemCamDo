﻿using _10DHTH.QuanLyTiemCamDo.DataAccess.Commons;
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
        public async Task<PagedResult<TaiSan>> GetPagingItems(PagingRequestBase request)
        {
            int totalRow = await _context.TaiSans.CountAsync();

            var items = await _context.TaiSans.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).ToListAsync();
            var pagedResult = new PagedResult<TaiSan>()
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
            var type = await _context.LoaiTaiSans.Select(x => new TypeViewModel()
            {
                MaLoai = x.MaLoai,
                TenLoai = x.TenLoai
            }).ToListAsync();
            return type;

        }
        public async Task<ResultList<TaiSan>> GetItemByIdTypeAsync(int id)
        {
            var type = await _context.TaiSans.Where(x => x.MaLoai == id).ToListAsync();
            return new ResultList<TaiSan>
            {
                Data = type,
                Message = "ok",
                Code = 200,
            };
        }
        public async Task<ResultList<TaiSan>> SearchItemAsync(string name)
        {
            var result = await _context.TaiSans.Where(t => t.TenTaiSan.Contains(name)).ToListAsync();
            return new ResultList<TaiSan>
            {
                Data = result,
                Message = "ok",
                Code = 200,
            };
        }
        public async Task<ResultObject<TaiSan>> DetailsItemAsync(int id)
        {
            var result = await _context.TaiSans.FindAsync(id);
            if (result == null)
            {
                return new ResultObject<TaiSan>
                {
                    Code = 404,
                    Message = "Item is not exits",
                };
            }
            return new ResultObject<TaiSan>
            {
                Data = result,
                Message = "ok",
                Code = 200,
            };
        }
    }
}

