using LittleToDoList.Business.Entities;

namespace LittleToDoList.Application.Dto.Mapping;

public static class TaskItemMappingExtension
{
    public static ToDoItemDto ToDto(this ToDo entity)
    {
        return new ToDoItemDto(entity.Id, entity.Name, entity.CreationDate, entity.AssignedUserId)
        {
            CompletionDate = entity.CompletionDate,
            Description = entity.Description,
            IsDone = entity.IsDone
        };
    }
}