
using FluentValidation;
using MicroelectronicsWarehouse.DTOs;

public class ComponentDtoValidator : AbstractValidator<ComponentDto>
{
    public ComponentDtoValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Назва є обов'язковою");
        RuleFor(c => c.Description).MaximumLength(500);
        RuleFor(c => c.Quantity).GreaterThanOrEqualTo(0);
        RuleFor(c => c.CategoryId).GreaterThan(0);
        RuleFor(c => c.SupplierId).GreaterThan(0);
    }
}
