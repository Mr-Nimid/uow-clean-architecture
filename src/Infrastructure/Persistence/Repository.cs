using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Entity<TKey>
{
    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }
    public async Task<TEntity?> GetByIdAsync(TKey id) => await _dbSet.FindAsync(id);
    public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();
    public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);
    public void Update(TEntity entity) => _dbSet.Update(entity);
    public void Delete(TEntity entity) => _dbSet.Remove(entity);
}
