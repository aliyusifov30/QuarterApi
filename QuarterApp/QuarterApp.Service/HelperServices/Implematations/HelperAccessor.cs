using Microsoft.AspNetCore.Http;
using QuarterApp.Service.HelperServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Service.HelperServices.Implematations
{
    public class HelperAccessor : IHelperAccessor
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public HelperAccessor(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public string BaseUrl => $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}{_contextAccessor.HttpContext.Request.Path}";
    }
}
