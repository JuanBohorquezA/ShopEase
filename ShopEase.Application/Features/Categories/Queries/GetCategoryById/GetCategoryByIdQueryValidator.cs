using FluentValidation;

namespace ShopEase.Application.Features.Categorys.Queries.GetCategoryById;

internal class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
{
    public GetCategoryByIdQueryValidator()
    {
        RuleFor(c=> c.CategoryId)
            .NotNull().WithMessage("CategoryId cannot be null.")
            .NotEmpty().WithMessage("CategoryId is required.")
            .Must(id => id != Guid.Empty).WithMessage("CategoryId must be a valid GUID.");
    }
}
