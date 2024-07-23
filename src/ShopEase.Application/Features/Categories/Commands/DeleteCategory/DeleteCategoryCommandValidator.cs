using FluentValidation;

namespace ShopEase.Application.Features.Categorys.Commands.DeleteCategory;

internal class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(c=>c.CategoryId)
            .NotNull().WithMessage("CategoryId cannot be null.")
            .NotEmpty().WithMessage("CategoryId is required.")
            .Must(id => id != Guid.Empty).WithMessage("CategoryId must be a valid GUID.");
    }
}
