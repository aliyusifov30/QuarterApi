using FluentValidation;
using QuarterApp.Service.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Service.Validators.CategoriesValidator
{
    public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidator()
        {
            RuleFor(x => x.Name).
                NotNull().NotEmpty().MinimumLength(2).MaximumLength(25);
        }
    }
}
