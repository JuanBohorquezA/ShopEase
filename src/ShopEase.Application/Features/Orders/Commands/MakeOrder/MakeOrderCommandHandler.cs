using ShopEase.Application.Abstractions.Messaging;
using ShopEase.Application.Common;
using ShopEase.Domain.Abstractions;

namespace ShopEase.Application.Features.Orders.Commands.MakeOrder;

public class MakeOrderCommandHandler : ICommandHandler<MakeOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public MakeOrderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(MakeOrderCommand command, CancellationToken cancellationToken)
    {
        foreach(var p in command.products)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(p.Key);
            if (product is null)
                return Result.FailureResult($"ProductId {p.Key} does not exist.");

        }

        return Result.SuccessResult();
    }
}
