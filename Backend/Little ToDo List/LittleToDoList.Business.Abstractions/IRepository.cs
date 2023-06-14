using System.Linq.Expressions;

namespace LittleToDoList.Business.Abstractions;

public interface IRepository { }

public interface IRepository<TEntity> : IRepository where TEntity : IEntity
{
    Task<TEntity?> GetOneAsync(object id);
    Task<TEntity> GetOneRequiredAsync(object id);
    Task<ICollection<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        params string[] includeProperties);

    Task<TEntity> CreateOneAsync(TEntity entity);
    
    Task<TEntity> UpdateAsync(object update, object id);
    
    Task DeleteOneAsync(object keys);
    
    Task SaveChangesAsync();
    Task<IEnumerable<TEntity>> GetPagedAsync(int pageSize, int pageNumber);
}