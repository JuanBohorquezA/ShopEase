using ShopEase.Application.Abstractions.Messaging;
using ShopEase.Application.Common;
using ShopEase.Application.Features.Orders.Response;
using ShopEase.Domain.Abstractions;

namespace ShopEase.Application.Features.Orders.Queries.GetAllOrder;

public class GetAllOrderQueryHandler : IQueryHandler<GetAllOrderQuery, IEnumerable<OrderResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllOrderQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<OrderResponse>>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWork.OrderRepository.GetAsync();

        var orderResponse = order.Select(o=> new  OrderResponse)
    }
}
