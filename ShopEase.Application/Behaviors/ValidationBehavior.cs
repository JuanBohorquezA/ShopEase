using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ShopEase.Domain.Exceptions;

namespace ShopEase.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var validationFailures = new List<ValidationFailure>();

        foreach (var validator in _validators)
        {
            var validationResult = await validator.ValidateAsync(context, cancellationToken);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    validationFailures.Add(error);
                }
            }
        }

        if (validationFailures.Count > 0)
            throw new ValidationException(validationFailures);



        return await next();
    }
}
