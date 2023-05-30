using LittleToDoList.Infrastructure.Errors.Abstractions;

namespace LittleToDoList.Infrastructure.Errors;

public class ItemDuplicatedErrorException : InfrastructureErrorException
{
    public ItemDuplicatedErrorException(string? message) : base(message)
    {
    }

    public ItemDuplicatedErrorException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public ItemDuplicatedErrorException()
    {
    }
}