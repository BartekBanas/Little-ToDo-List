using LittleToDoList.Business.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LittleToDoList.Infrastructure.Repositories;

public class Repository<TEntity, TDbContext> : IRepository<TEntity>
    where TEntity : class, IEntity
    where TDbContext : DbContext
{
    private readonly DbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;
    private readonly Func<Task> _saveChangesAsyncDelegate;
    private readonly IMediator _mediator;

    public Repository(TDbContext dbContext, IMediator mediator)
    {
        _dbContext = dbContext;
        _mediator = mediator;
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
    
    public virtual async Task<TEntity> CreateOneAsync(TEntity entity)
    {
        _dbSet.Add(entity);

        return await Task.FromResult(entity);
    }
    
    public virtual async Task<TEntity> UpdateAsync(object update, int id)
    {
        var entity = await GetOneAsync(id);

        _dbSet.Attach(entity).CurrentValues.SetValues(update);
        _dbSet.Attach(entity).State = EntityState.Modified;

        return entity;
    }
    
    public virtual async Task SaveChangesAsync()
    {
        await _mediator.DispatchDomainEventsAsync(_dbContext);

        await _saveChangesAsyncDelegate();
    }
}