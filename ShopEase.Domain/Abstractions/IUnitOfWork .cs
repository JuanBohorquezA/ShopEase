using ShopEase.Domain.Entities.Main;
using ShopEase.Domain.Entities.Relations;

namespace ShopEase.Domain.Abstractions;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Category> CategoryRepository { get; }
    IGenericRepository<Order> OrderRepository { get; }
    IGenericRepository<Product> ProductRepository { get; }
    IGenericRepository<OrderProduct> OrderProductRepository { get; }

    Task SaveAsync(CancellationToken cancellationToken);
}
