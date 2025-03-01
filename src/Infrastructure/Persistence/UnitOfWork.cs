using Domain.Entities;
using Application.Interfaces;
using System.Collections.Concurrent;

namespace Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly ConcurrentDictionary<Type, object> _repositories = new();

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : Entity<TKey>
    {
        var type = typeof(TEntity);
        if (!_repositories.ContainsKey(type))
        {
            var repository = new Repository<TEntity, TKey>(_context);
            _repositories[type] = repository;
        }
        return (IRepository<TEntity, TKey>)_repositories[type];
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    public async Task<int> CommitAsync() => await _context.SaveChangesAsync();
    public void Dispose() => _context.Dispose();
}
}
