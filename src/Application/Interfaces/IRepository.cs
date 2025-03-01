using Domain.Entities;

namespace Application.Interfaces;

public interface IRepository<TEntity, TKey> where TEntity : Entity<TKey>
{
    Task<TEntity?> GetByIdAsync(TKey id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}