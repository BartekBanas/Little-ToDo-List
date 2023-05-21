namespace LittleToDoList.Business.Abstractions;

public interface IRepository { }

public interface IRepository<TEntity> : IRepository where TEntity : IEntity
{
    Task<TEntity?> GetOneAsync(int id);

    public Task<ICollection<TEntity>> GetAllAsync();


    public Task DeleteOneAsync(int keys);

    public Task<TEntity> CreateOneAsync(TEntity entity);
    Task<TEntity> UpdateAsync(object update, int id);
    
    Task SaveChangesAsync();
}