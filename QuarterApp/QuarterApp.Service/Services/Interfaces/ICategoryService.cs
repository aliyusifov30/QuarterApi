using QuarterApp.Core.Entiteis;
using QuarterApp.Service.DTOs;
using QuarterApp.Service.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuarterApp.Service.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryPostDto postDto);
        Task UpdateAsync(CategoryPostDto postDto, int id);
        Task<CategoryGetDto> GetByIdAsync(int id);
        Task<PagenatedListDto<CategoryListItemDto>> GetAllFiltered(int page , string search);
        Task<bool> IsExistAsync(Expression<Func<Category,bool>> exp);
        Task Delete(int id);
    }
}
