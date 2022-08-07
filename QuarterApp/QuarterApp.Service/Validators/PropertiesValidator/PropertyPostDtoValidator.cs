using FluentValidation;
using QuarterApp.Service.DTOs.PropertyDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuarterApp.Service.Validators.PropertiesValidator
{
    public class PropertyPostDtoValidator : AbstractValidator<PropertyPostDto>
    {

        public PropertyPostDtoValidator()
        {
            RuleFor(x => x.Name).
                NotEmpty().NotNull().MaximumLength(100);

            RuleFor(x => x.Description).
                MaximumLength(500);

            RuleFor(x => x.Address).
                NotNull().NotNull().MaximumLength(250);

            RuleFor(x => x.PosterImage).
                NotEmpty().NotNull().MaximumLength(100);

            RuleFor(x => x.CategoryId).
                NotEmpty().NotNull();

            RuleFor(x => x.Price).
                GreaterThanOrEqualTo(0);
            RuleFor(x => x.DaylyPrice).
                GreaterThanOrEqualTo(0);
            RuleFor(x => x.WeeklyPrice).
                GreaterThanOrEqualTo(0);
            RuleFor(x => x.MonthlyPrice).
                GreaterThanOrEqualTo(0);

            RuleFor(x => x.ImageFile);

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Price == null && x.DaylyPrice == null && x.WeeklyPrice == null && x.MonthlyPrice == 0)
                {
                    context.AddFailure("One Price must be not null");
                }
            });
            


        }

    }
}
