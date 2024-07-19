using Microsoft.EntityFrameworkCore;
using ShopEase.Domain.Abstractions;
using ShopEase.Persistence.Contexts;
using System.Linq.Expressions;

namespace ShopEase.Persistence.Repositories;

internal class GenericRepository<TEntity>(DataBaseContext context) : IGenericRepository<TEntity>
    where TEntity : class
{
    private readonly DataBaseContext _context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    private readonly char[] _separator = [','];

    public void Delete(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
            _dbSet.Attach(entity);
        _dbSet.Remove(entity);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var entityToDelete = await _dbSet.FindAsync(id);
        Delete(entityToDelete!);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable
        <TEntity>>? orderBy = null, string includeProperties = "", CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null)
            query = query.Where(filter);

        query = includeProperties.Split(_separator, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        return orderBy != null ? await orderBy(query).ToListAsync() : await query.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
       return await _dbSet.FindAsync(id);
    }

    public async Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }
}
