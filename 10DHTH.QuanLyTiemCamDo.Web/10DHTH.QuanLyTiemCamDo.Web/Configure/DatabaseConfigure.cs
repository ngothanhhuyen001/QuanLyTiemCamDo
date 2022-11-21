using _10DHTH.QuanLyTiemCamDo.DataAccess.Models;
using _10DHTH.QuanLyTiemCamDo.Service.Interfaces;
using _10DHTH.QuanLyTiemCamDo.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _10DHTH.QuanLyTiemCamDo.Web.Configure
{
    public static class DatabaseConfigure
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped((_) => new QuanLyTiemCamDoContext(configuration));
        
            services.AddScoped<IApiAuthService, ApiAuthService>();
            services.AddScoped<IItemService, ItemService>();



        }
    }
}
