using ShopEase.Application.Abstractions.Messaging;
using ShopEase.Application.Common;
using ShopEase.Domain.Abstractions;

namespace ShopEase.Application.Features.Orders.Commands.CancelOrder;

public class CancelOrderCommandHandler : ICommandHandler<CancelOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CancelOrderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CancelOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.OrderRepository.GetByIdAsync(command.OrderId, cancellationToken);
        if (order is null)
            return Result.FailureResult($"CategoryId {command.OrderId} does not exist.");

        _unitOfWork.OrderRepository.Delete(order, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.SuccessResult();
    }
}
