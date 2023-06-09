﻿using System.Linq.Expressions;
using LittleToDoList.Business.Abstractions;
using LittleToDoList.Infrastructure.Errors;
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
    
    public virtual async Task<TEntity?> GetOneAsync(object id)
    {
        var entity = await _dbSet.FindAsync(id);

        return entity;
    }
    
    public virtual async Task<TEntity> GetOneRequiredAsync(object id)
    {
        var entity = await GetOneAsync(id);

        if (entity == null)
            throw new ItemNotFoundErrorException(); 

        return entity;
    }

    public virtual async Task<ICollection<TEntity>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();

        return entities;
    }
    
    public virtual async Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        params string[] includeProperties)
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync();
        }
        else
        {
            return await query.ToListAsync();
        }
    }

    public virtual async Task<TEntity> CreateOneAsync(TEntity entity)
    {
        _dbSet.Add(entity);

        return await Task.FromResult(entity);
    }
    
    public virtual async Task<TEntity> UpdateAsync(object update, object id)
    {
        var entity = await GetOneRequiredAsync(id);

        _dbSet.Attach(entity).CurrentValues.SetValues(update);
        _dbSet.Attach(entity).State = EntityState.Modified;

        return entity;
    }
    
    public virtual async Task DeleteOneAsync(object keys)
    {
        var entity = await GetOneAsync(keys);

        if (entity != null) _dbSet.Remove(entity);
    }
    
    public virtual async Task<IEnumerable<TEntity>> GetPagedAsync(int pageSize, int pageNumber)
    {
        return await _dbSet.Skip(pageNumber * pageSize).Take(pageSize).ToListAsync();
    }
    
    public virtual async Task SaveChangesAsync()
    {
        await _mediator.DispatchDomainEventsAsync(_dbContext);

        await _saveChangesAsyncDelegate();
    }
}