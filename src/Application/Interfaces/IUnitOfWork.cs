using Domain.Entities;

namespace Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : Entity<TKey>;
    Task<int> SaveChangesAsync();
    Task<int> CommitAsync();
}