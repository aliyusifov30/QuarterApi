using AutoMapper;
using Microsoft.Extensions.Options;
using QuarterApp.Core;
using QuarterApp.Core.Entiteis;
using QuarterApp.Core.Models;
using QuarterApp.Service.CustomExpections;
using QuarterApp.Service.DTOs;
using QuarterApp.Service.DTOs.CategoryDTOs;
using QuarterApp.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuarterApp.Service.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AppSetting _appSetting;
        public CategoryService(IUnitOfWork unitOfWork , IMapper mapper , IOptions<AppSetting> appSetting)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appSetting = appSetting.Value;
        }
        public async Task CreateAsync(CategoryPostDto postDto)
        {
            await AlreadyExistException(postDto.Name);

            Category category = _mapper.Map<Category>(postDto);
            
            await _unitOfWork.CategoryRepository.InsertAsync(category);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(int id)
        {
            await NotFoundException(id);

            Category category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id);
            _unitOfWork.CategoryRepository.RemoveAsync(category);

            await _unitOfWork.CommitAsync();
        }

        public async Task<PagenatedListDto<CategoryListItemDto>> GetAllFiltered(int page, string search)
        {
            if (page < 0) throw new PageIndexFormatException("Page must be bigger then 0");

            var categories = await _unitOfWork.CategoryRepository.GetPagenatedAsync(page, _appSetting.PageSize, x=>string.IsNullOrWhiteSpace(search)?true:x.Name.Contains(search));

            IEnumerable<CategoryListItemDto> categoryListItemDto = _mapper.Map<IEnumerable<CategoryListItemDto>>(categories);

            PagenatedListDto<CategoryListItemDto> pagenatedListDto = new PagenatedListDto<CategoryListItemDto>(categoryListItemDto, _appSetting.PageSize, page);

            return pagenatedListDto;
        }

        public async Task<CategoryGetDto> GetByIdAsync(int id)
        {
            await NotFoundException(id);

            var category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id);
            
            CategoryGetDto categoryGetDto = _mapper.Map<CategoryGetDto>(category);

            return categoryGetDto;
        }

        public async Task<bool> IsExistAsync(Expression<Func<Category, bool>> exp)
        {
            return await _unitOfWork.CategoryRepository.IsExistAsync(exp);
        }

        public async Task UpdateAsync(CategoryPostDto postDto, int id)
        {

            await NotFoundException(id);
            Category category = await _unitOfWork.CategoryRepository.GetAsync(x => x.Id == id);

            await AlreadyExistException(postDto.Name,id);
            category.Name = postDto.Name;

            await _unitOfWork.CommitAsync();
        }

        private async Task AlreadyExistException(string data , int? id = null)
        {
            if (await _unitOfWork.CategoryRepository.IsExistAsync(x => x.Id != id && x.Name.ToLower() == data.ToLower()))
                throw new AlreadyExistException($"{data} Already Exist");
        }
        private async Task NotFoundException(int id)
        {
            if(await _unitOfWork.CategoryRepository.IsExistAsync(x => x.Id != id))
                throw new  NotFoundException($"{id} Item Not Found");
        }
    }
}
