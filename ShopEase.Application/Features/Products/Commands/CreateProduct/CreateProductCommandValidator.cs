using FluentValidation;

namespace ShopEase.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p=>p.Name)
            .NotNull().WithMessage("Name cannot be null.")
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(p=> p.Description)
            .NotNull().WithMessage("Description cannot be null.")
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

        RuleFor(p=>p.Quantity)
            .NotNull().WithMessage("Quantity cannot be null.")
             .Must(quantity => quantity > 0).WithMessage("Quantity value is not valid.");

        RuleFor(p => p.Price)
            .NotNull().WithMessage("Price cannot be null.")
            .Must(price => price > 0).WithMessage("Price value is not valid.");

        RuleFor(p => p.CategoryId)
            .NotNull().WithMessage("CategoryId cannot be null.")
            .NotEmpty().WithMessage("CategoryId is required.")
            .Must(id => id != Guid.Empty).WithMessage("CategoryId must be a valid GUID.");
    }
}
