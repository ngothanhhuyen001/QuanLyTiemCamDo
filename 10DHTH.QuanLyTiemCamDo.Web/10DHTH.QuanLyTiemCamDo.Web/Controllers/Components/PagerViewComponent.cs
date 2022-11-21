using _10DHTH.QuanLyTiemCamDo.DataAccess.Commons;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _10DHTH.QuanLyTiemCamDo.Web.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
