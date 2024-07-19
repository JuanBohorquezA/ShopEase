using ShopEase.Domain.Abstractions;
using ShopEase.Domain.Entities.Main;
using ShopEase.Domain.Entities.Relations;
using ShopEase.Persistence.Contexts;
using ShopEase.Persistence.Repositories;

namespace ShopEase.Persistence.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataBaseContext _context = new();
    private IGenericRepository<Category>? _categoryRepository;
    private IGenericRepository<Order>? _orderRepository;
    private IGenericRepository<Product>? _productRepository;
    private IGenericRepository<OrderProduct>? _orderProductRepository;


    public IGenericRepository<Category> CategoryRepository =>
        _categoryRepository ??= new GenericRepository<Category>(_context);

    public IGenericRepository<Order> OrderRepository => 
        _orderRepository ??= new GenericRepository<Order>(_context);

    public IGenericRepository<Product> ProductRepository => 
        _productRepository ??= new GenericRepository<Product>(_context);

    public IGenericRepository<OrderProduct> OrderProductRepository =>
        _orderProductRepository ??= new GenericRepository<OrderProduct>(_context);

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task SaveAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync();
    }
}
