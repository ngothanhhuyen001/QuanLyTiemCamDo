using _10DHTH.QuanLyTiemCamDo.DataAccess.Commons;
using _10DHTH.QuanLyTiemCamDo.DataAccess.Enum;
using _10DHTH.QuanLyTiemCamDo.DataAccess.Models;
using _10DHTH.QuanLyTiemCamDo.DataAccess.ViewModels;
using _10DHTH.QuanLyTiemCamDo.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<ItemInput>> GetAll()
        {
            var items = await _context.TaiSans
                .Include(t=>t.MaLoaiNavigation)
                .Include(t=>t.MaTrangThaiNavigation)
                .Where(t=>t.MaTrangThai != 2)
                .Select(t => new ItemInput
            {
                MaTaiSan = t.MaTaiSan,
                TenTaiSan = t.TenTaiSan,
                TenLoai = t.MaLoaiNavigation.TenLoai,
                Nsx = t.Nsx,
                ThuongHieu = t.ThuongHieu,
                HinhAnh = t.HinhAnh,
                NoiDung = t.NoiDung,
                GiaBan=t.GiaBan,
                NgayThanhLy=t.NgayThanhLy,  
                TenTrangThai = t.MaTrangThaiNavigation.TenTrangThai,               
            }).ToListAsync();
            if (items != null)
            {
                return items;
            }
            else
                throw new Exception("Null");
        }

        public async Task<ItemInput> UpdateItem(int id, TaiSan ts)
        {
            var item = await _context.TaiSans.Where(p => p.MaTaiSan == id).FirstOrDefaultAsync();
            if (item != null)
            {
                item.MaTaiSan = ts.MaTaiSan;
                item.TenTaiSan = ts.TenTaiSan ?? item.TenTaiSan;
                item.MaLoai = ts.MaLoai;
                item.Nsx = ts.Nsx;
                item.ThuongHieu = ts.ThuongHieu;
                item.HinhAnh = ts.HinhAnh;
                item.NoiDung = ts.NoiDung;
                item.GiaBan = ts.GiaBan;
                item.NgayThanhLy = ts.NgayThanhLy;
                item.MaTrangThai = ts.MaTrangThai;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Không tìm thấy" + id);
            }
            var result = await _context.TaiSans.Include(t => t.MaLoaiNavigation).Include(t => t.MaTrangThaiNavigation).Where(t => t.MaTaiSan == id).Select(t => new ItemInput
            {
                MaTaiSan = t.MaTaiSan,
                TenTaiSan = t.TenTaiSan,
                TenLoai = t.MaLoaiNavigation.TenLoai,
                Nsx = t.Nsx,
                ThuongHieu = t.ThuongHieu,
                HinhAnh = t.HinhAnh,
                NoiDung = t.NoiDung,
                GiaBan = t.GiaBan,
                NgayThanhLy = t.NgayThanhLy,
                TenTrangThai = t.MaTrangThaiNavigation.TenTrangThai,
            }).FirstOrDefaultAsync();
            if (result == null)
            {
                throw new Exception("NULL");
            }
            return result;
        }
        public async Task<TaiSan> GetByIdItem(int id)
        {
            var taisan = await _context.TaiSans.FindAsync(id);
            if (taisan != null)
            {
                return taisan;
            }
            else
            {
                throw new Exception("Null");
            }
        }

    }
}

