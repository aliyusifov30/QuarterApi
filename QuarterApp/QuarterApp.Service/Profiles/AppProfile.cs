using AutoMapper;
using QuarterApp.Core.Entiteis;
using QuarterApp.Service.DTOs.CategoryDTOs;
using QuarterApp.Service.DTOs.PropertyDTOs;
using QuarterApp.Service.HelperServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Service.Profiles
{
    public class AppProfile : Profile
    {
        private readonly IHelperAccessor _helperAccessor;
        public AppProfile(IHelperAccessor helperAccessor)
        {

            _helperAccessor = helperAccessor;

            CreateMap<CategoryPostDto, Category>();
            CreateMap<Category,CategoryListItemDto>();
            CreateMap<Category,CategoryGetDto>();

            CreateMap<PropertyPostDto,Property>();
            CreateMap<Property, PropertyGetDto>()
                .ForMember(dest => dest.FilePath, form => form.MapFrom(src => _helperAccessor.BaseUrl + "uploads/properties" + src.PosterImage));

        }
    }
}
