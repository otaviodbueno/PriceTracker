using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace PriceTracker.Data;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly PriceTrackerContext _ctx;
    protected readonly DbSet<T> _dbSet;

    public Repository(PriceTrackerContext context)
    {
        _ctx = context;
        _dbSet = context.Set<T>();
    }

    public DbSet<T> Entity()
    {
        return _ctx.Set<T>();
    }

    public T? GetById(int id) => _dbSet.Find(id);

    public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
    public IEnumerable<T> List() => _dbSet.ToList();

    public async Task<List<T>> ListAsync() => await _dbSet.ToListAsync();

    public async Task<List<T>> ListAsNoTrackingAsync() => await _dbSet.AsNoTracking().ToListAsync();
    public IEnumerable<T> List(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).ToList();

    public async Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate) => await _dbSet.Where(predicate).ToListAsync();

    public async Task<List<T>> ListAsNoTrackingAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _ctx.SaveChangesAsync();
    }
}
