using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using App.CoreLib.Module;
using App.Production.Contract;
using App.Production.Business;

namespace App.Production.Web
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IStockGroupQuery, StockGroupQuery>();
            services.AddScoped<IStockTypeQuery, StockTypeQuery>();
        }

        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment env)
        {

        }
    }
}
