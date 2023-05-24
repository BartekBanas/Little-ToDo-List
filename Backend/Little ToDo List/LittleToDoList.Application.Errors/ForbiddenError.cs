using LittleToDoList.Application.Errors.Abstractions;

namespace LittleToDoList.Application.Errors;

public class ForbiddenError : ErrorException
{
    public ForbiddenError()
    {
    }

    public ForbiddenError(string? message) : base(message)
    {
    }
}