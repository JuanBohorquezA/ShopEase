using ShopEase.Application.Abstractions.Messaging;
using ShopEase.Application.Common;
using ShopEase.Application.Features.Products.Response;
using ShopEase.Domain.Abstractions;

namespace ShopEase.Application.Features.Products.Queries.GetAllProduct;

public class GetAllProductQueryHandler : IQueryHandler<GetAllProductQuery, IEnumerable<ProductResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllProductQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<ProductResponse>>> Handle(GetAllProductQuery query, CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.ProductRepository.GetAsync();

        var productsResponse = products.Select(product => new ProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Quantity,
            product.Price,
            product.CategoryId));

        return Result<IEnumerable<ProductResponse>>.SuccessResult(productsResponse);
    }
}
