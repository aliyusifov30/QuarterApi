using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QuarterApp.Api.Extentions.ServiceExtentions;
using QuarterApp.Core;
using QuarterApp.Core.Models;
using QuarterApp.Data;
using QuarterApp.Service.CustomExpections;
using QuarterApp.Service.HelperServices.Implematations;
using QuarterApp.Service.HelperServices.Interfaces;
using QuarterApp.Service.Profiles;
using QuarterApp.Service.Services.Implementations;
using QuarterApp.Service.Services.Interfaces;
using QuarterApp.Service.Validators.CategoriesValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbServices(Configuration);

            services.AddAllScopedService();

            services.Configure<AppSetting>(Configuration.GetSection("AppSetting"));

            services.AddMapperService();
            services.AddSingleton<IHelperAccessor, HelperAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.AddExceptionService();

            app.UseStaticFiles();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
