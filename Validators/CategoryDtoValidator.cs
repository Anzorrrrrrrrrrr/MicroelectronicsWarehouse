using FluentValidation;
using MicroelectronicsWarehouse.DTOs;

public class CategoryDtoValidator : AbstractValidator<CategoryDto>
{
    public CategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Назва категорії обов’язкова")
            .MaximumLength(100).WithMessage("Назва не може перевищувати 100 символів");
    }
}
