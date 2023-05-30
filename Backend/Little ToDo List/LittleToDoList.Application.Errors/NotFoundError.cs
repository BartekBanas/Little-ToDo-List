using LittleToDoList.Application.Errors.Abstractions;

namespace LittleToDoList.Application.Errors;

public class NotFoundError : ErrorException
{
    public NotFoundError(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}