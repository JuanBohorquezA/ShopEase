using System.Linq.Expressions;

namespace ShopEase.Domain.Abstractions;

public interface IGenericRepository<TEntity>
    where TEntity : class

{
    public Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "", CancellationToken cancellationToken = default);

    public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default);

    public void Delete(TEntity entity, CancellationToken cancellationToken = default);

    public void Update(TEntity entity, CancellationToken cancellationToken = default);
}
