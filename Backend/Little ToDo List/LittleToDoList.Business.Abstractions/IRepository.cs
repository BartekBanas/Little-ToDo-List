namespace LittleToDoList.Business.Abstractions;

public interface IRepository { }

public interface IRepository<TEntity> : IRepository where TEntity : IEntity
{
    Task<TEntity?> GetOneAsync(object id);
    Task<TEntity> GetOneRequiredAsync(object id);
    Task<ICollection<TEntity>> GetAllAsync();

    Task<TEntity> CreateOneAsync(TEntity entity);
    
    Task<TEntity> UpdateAsync(object update, object id);
    
    Task DeleteOneAsync(object keys);
    
    Task SaveChangesAsync();
    Task<IEnumerable<TEntity>> GetPagedAsync(int pageSize, int pageNumber);
}