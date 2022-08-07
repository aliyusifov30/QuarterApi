using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuarterApp.Data;
using QuarterApp.Service.Validators.CategoriesValidator;

namespace QuarterApp.Api.Extentions.ServiceExtentions
{
    public static class DBServiceExtention
    {
        
        public static void AddDbServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining(typeof(CategoryPostDtoValidator)));

            services.AddDbContext<DataContext>(opt => { opt.UseSqlServer(configuration.GetConnectionString("Default")); });
        }

    }
}
