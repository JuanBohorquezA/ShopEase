using FluentValidation;

namespace ShopEase.Application.Features.Orders.Commands.CancelOrder;

internal class CancelOrderCommandValidator : AbstractValidator<CancelOrderCommand>
{
    public CancelOrderCommandValidator()
    {
        RuleFor(o => o.OrderId)
             .NotNull().WithMessage("OrderId cannot be null.")
             .NotEmpty().WithMessage("OrderId is required.")
             .Must(id => id != Guid.Empty).WithMessage("OrderId must be a valid GUID.");
    }
}
