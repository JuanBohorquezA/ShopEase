using FluentValidation;

namespace ShopEase.Application.Features.Products.Commands.DeleteProduct;

internal class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(p=>p.productId)
            .NotNull().WithMessage("productId cannot be null.")
            .NotEmpty().WithMessage("productId is required.")
            .Must(id => id != Guid.Empty).WithMessage("productId must be a valid GUID.");
    }
}
