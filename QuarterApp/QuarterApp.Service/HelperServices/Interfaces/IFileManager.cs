using Microsoft.AspNetCore.Http;
using QuarterApp.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuarterApp.Service.HelperServices.Interfaces
{
    public interface IFileManager
    {
        Task<SavedFileDto> Save(IFormFile file,string folder);
    }
}
