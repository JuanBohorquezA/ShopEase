using FluentValidation;

namespace ShopEase.Application.Features.Categorys.Commands.UpdateCategory;

internal class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(c=> c.CategoryId)
            .NotNull().WithMessage("CategoryId cannot be null.")
            .NotEmpty().WithMessage("CategoryId is required.")
            .Must(id => id != Guid.Empty).WithMessage("CategoryId must be a valid GUID.");

        RuleFor(c=> c.Name)
            .NotNull().WithMessage("Name cannot be null.")
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
        
        RuleFor(c=> c.Description)
            .NotNull().WithMessage("Description cannot be null.")
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
    }
}
