namespace LittleToDoList.Abstractions;

public interface IRepository { }

public interface IRepository<TEntity> : IRepository where TEntity : IEntity
{
    Task<TEntity?> GetOneAsync(int id);
}