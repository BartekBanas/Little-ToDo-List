using LittleToDoList.Application.Errors.Abstractions;

namespace LittleToDoList.Application.Errors;

public class BadRequestError : ErrorException
{
    public BadRequestError(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}