using FluentValidation;

namespace ShopEase.Application.Features.Products.Commands.UpdateProduct;

internal class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(p => p.productId)
            .NotNull().WithMessage("productId cannot be null.")
            .NotEmpty().WithMessage("productId is required.")
            .Must(id => id != Guid.Empty).WithMessage("productId must be a valid GUID.");

        RuleFor(p=>p.Quantity)
            .NotNull().WithMessage("Quantity cannot be null.")
            .Must(quantity => quantity > 0).WithMessage("Quantity value is not valid.");

        RuleFor(p=>p.Price)
            .NotNull().WithMessage("Price cannot be null.")
            .Must(price => price > 0).WithMessage("Price value is not valid.");
    }
}
