using LittleToDoList.Business.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LittleToDoList.Infrastructure.Repositories;

public class Repository<TEntity, TDbContext> : IRepository<TEntity>
    where TEntity : class, IEntity
    where TDbContext : DbContext
{
    private readonly DbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;
    private readonly Func<Task> _saveChangesAsyncDelegate;
    
    public Repository(TDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();

        _saveChangesAsyncDelegate = async () => { await dbContext.SaveChangesAsync(); };
    }
    
    public virtual async Task<TEntity?> GetOneAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);

        return entity;
    }

    public virtual async Task<ICollection<TEntity>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();

        return entities;
    }
    
    public virtual async Task DeleteOneAsync(int keys)
    {
        var entity = await GetOneAsync(keys);

        if (entity != null) _dbSet.Remove(entity);
    }
    
    public virtual Task<TEntity> CreateOneAsync(TEntity entity)
    {
        _dbSet.Add(entity);

        return Task.FromResult(entity);
    }
}