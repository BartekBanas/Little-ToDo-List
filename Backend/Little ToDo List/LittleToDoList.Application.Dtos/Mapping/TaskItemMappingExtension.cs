using LittleToDoList.Business.Entities;

namespace LittleToDoList.Application.Dto.Mapping;

public static class TaskItemMappingExtension
{
    public static ToDoDto ToDto(this ToDo entity)
    {
        return new ToDoDto(entity.Id, entity.Name, entity.CreationDate, entity.AssignedUserId)
        {
            CompletionDate = entity.CompletionDate,
            Description = entity.Description,
            IsDone = entity.IsDone
        };
    }
}