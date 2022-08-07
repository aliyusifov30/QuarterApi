using Microsoft.AspNetCore.Http;
using QuarterApp.Service.DTOs;
using QuarterApp.Service.HelperServices.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace QuarterApp.Service.HelperServices.Implematations
{
    public class FileManager : IFileManager
    {

        private readonly IHelperAccessor _helperAccessor;
        public FileManager(IHelperAccessor helperAccessor)
        {
            _helperAccessor = helperAccessor;
        }

        public async Task<SavedFileDto> Save(IFormFile file, string folder)
        {

            string fileName = file.FileName;
            
            if (fileName.Length > 64)
                fileName = fileName.Substring(0, 64);

            fileName += Guid.NewGuid().ToString();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", folder,fileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            SavedFileDto savedDto = new SavedFileDto
            {
                FileName = fileName,
                Path = _helperAccessor.BaseUrl + "uploads/properties" + fileName
            };

            return savedDto;
        }
    }
}
