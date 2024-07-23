using FluentValidation;

namespace ShopEase.Application.Features.Orders.Commands.MakeOrder;

internal class MakeOrderCommandValidator : AbstractValidator<MakeOrderCommand>
{
    public MakeOrderCommandValidator()
    {
        RuleFor(o => o.products)
           .NotNull().WithMessage("Products dictionary cannot be null.")
           .Must(products => products.Count > 0).WithMessage("Products dictionary must contain at least one item.");

        RuleForEach(o => o.products)
            .ChildRules(product =>
            {
                product.RuleFor(p => p.Key)
                    .NotNull().WithMessage("ProductId cannot be null.")
                    .NotEmpty().WithMessage("ProductId is required.")
                    .Must(id => id != Guid.Empty).WithMessage("ProductId must be a valid GUID.");

                product.RuleFor(p => p.Value)
                    .NotNull().WithMessage("Quantity cannot be null.")
                    .Must(quantity => quantity > 0).WithMessage("Quantity value is not valid.");
            });
            
    }
}
