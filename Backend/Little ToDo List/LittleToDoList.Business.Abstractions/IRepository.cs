using System.Linq.Expressions;

namespace LittleToDoList.Business.Abstractions;

public interface IRepository { }

public interface IRepository<TEntity> : IRepository where TEntity : IEntity
{
    Task<TEntity?> GetOneAsync(object id);
    Task<TEntity> GetOneRequiredAsync(int id);
    Task<ICollection<TEntity>> GetAllAsync();

    Task<TEntity> CreateOneAsync(TEntity entity);
    
    Task<TEntity> UpdateAsync(object update, int id);
    
    Task DeleteOneAsync(int keys);
    
    Task SaveChangesAsync();
}