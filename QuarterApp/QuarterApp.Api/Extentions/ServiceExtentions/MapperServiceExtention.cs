using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using QuarterApp.Service.HelperServices.Interfaces;
using QuarterApp.Service.Profiles;

namespace QuarterApp.Api.Extentions.ServiceExtentions
{
    public static class MapperServiceExtention
    {
        public static void AddMapperService(this IServiceCollection services)
        {
            services.AddSingleton(provider => new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AppProfile(provider.GetService<IHelperAccessor>()));
            }).CreateMapper());
        }

    }
}
