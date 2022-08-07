using Microsoft.Extensions.DependencyInjection;
using QuarterApp.Core;
using QuarterApp.Data;
using QuarterApp.Service.HelperServices.Implematations;
using QuarterApp.Service.HelperServices.Interfaces;
using QuarterApp.Service.Services.Implementations;
using QuarterApp.Service.Services.Interfaces;

namespace QuarterApp.Api.Extentions.ServiceExtentions
{
    public static class ScopedServiceExtention
    {

        public static void AddAllScopedService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IFileManager, FileManager>();

        }

    }
}
