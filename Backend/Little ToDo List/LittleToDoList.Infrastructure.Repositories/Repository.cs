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
    
    public Task<TEntity?> GetOneAsync(int id)
    {
        throw new NotImplementedException();
    }
}