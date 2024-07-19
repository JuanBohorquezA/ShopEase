using FluentValidation;

namespace ShopEase.Application.Features.Products.Queries.GetProductById;

internal class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(p => p.productId)
           .NotNull().WithMessage("productId cannot be null.")
           .NotEmpty().WithMessage("productId is required.")
           .Must(id => id != Guid.Empty).WithMessage("productId must be a valid GUID.");
    }
}
