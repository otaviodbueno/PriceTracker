namespace PriceTracker.Data;
using System.Linq.Expressions;

public interface IRepository<T> where T : class
{
    T? GetById(int id);
    Task<T?> GetByIdAsync(long id);

    IEnumerable<T> List();
    Task<List<T>> ListAsync();
    Task<List<T>> ListAsNoTrackingAsync();

    IEnumerable<T> List(Expression<Func<T, bool>> predicate);
    Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> ListAsNoTrackingAsync(Expression<Func<T, bool>> predicate);

    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);

    Task SaveChangesAsync();
}
