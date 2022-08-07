using AutoMapper;
using QuarterApp.Core;
using QuarterApp.Core.Entiteis;
using QuarterApp.Service.CustomExpections;
using QuarterApp.Service.DTOs;
using QuarterApp.Service.DTOs.PropertyDTOs;
using QuarterApp.Service.HelperServices.Interfaces;
using QuarterApp.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuarterApp.Service.Services.Implementations
{
    public class PropertyService : IPropertyService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;
        public PropertyService(IUnitOfWork unitOfWork , IMapper mapper , IFileManager fileManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileManager = fileManager;
        }

        public  async Task<PropertyCreateReturnDto> Create(PropertyPostDto postDto)
        {

            if(postDto.ImageFile == null)
            {
                throw new NotFoundException("ImageFile is Not Null");
            }
            
            if (postDto.ImageFile.ContentType!="image/jpeg"&&postDto.ImageFile.ContentType != "image/png")
            {
                throw new FileFormatException("File must be jpeg or png");
            }

            if(postDto.ImageFile.Length > 1048576)
            {
                throw new FileFormatException("File must be 2mb");
            }

            Property property = _mapper.Map<Property>(postDto);
            SavedFileDto savedDto = await _fileManager.Save(postDto.ImageFile, "properties");
            
            property.PosterImage = savedDto.FileName;

            PropertyCreateReturnDto returnDto = new PropertyCreateReturnDto
            {
                Name = property.Name,
                Address = property.Address,
                Path = savedDto.Path
            };

            return returnDto;
        }

        public async Task<PropertyGetDto> GetById(int id)
        {
            var property = _unitOfWork.ProperyRepository.GetAsync(x => x.Id == id);

            if (property == null) throw new NotFoundException("Property not found by id : " + id);

            PropertyGetDto propertyGet = _mapper.Map<PropertyGetDto>(property);
         
            return propertyGet;
        }
    }
}
