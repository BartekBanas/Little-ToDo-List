using LittleToDoList.Business.Entities;

namespace LittleToDoList.Application.Dto.Mapping;

public static class TaskItemMappingExtension
{
    public static TaskItemDto ToDto(this TaskItem entity)
    {
        return new TaskItemDto(entity.Id, entity.Name, entity.CreationDate)
        {
            CompletionDate = entity.CompletionDate,
            Description = entity.Description,
            IsDone = entity.IsDone
        };
    }
    
}