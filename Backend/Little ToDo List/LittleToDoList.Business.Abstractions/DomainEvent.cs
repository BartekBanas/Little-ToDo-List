using MediatR;

namespace LittleToDoList.Business.Abstractions;

public interface IDomainEvent : INotification
{
    
}

public abstract class DomainEvent<TEntity> : IDomainEvent where TEntity : IEntity
{
    
}