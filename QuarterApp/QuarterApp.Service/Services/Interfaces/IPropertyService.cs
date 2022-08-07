using QuarterApp.Service.DTOs.PropertyDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuarterApp.Service.Services.Interfaces
{
    public interface IPropertyService
    {
        Task<PropertyCreateReturnDto> Create(PropertyPostDto postDto);
        Task<PropertyGetDto> GetById(int id);
    }
}
