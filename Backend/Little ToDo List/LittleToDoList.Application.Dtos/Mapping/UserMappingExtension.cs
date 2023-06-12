using LittleToDoList.Business.Entities;

namespace LittleToDoList.Application.Dto.Mapping;

public static class UserMappingExtension
{
    public static UserDto ToDto(this User entity)
    {
        return new UserDto(entity.Id, entity.Name, entity.CreationDate)
        {
            CreationDate = entity.CreationDate,
            Name = entity.Name,
            Id = entity.Id
        };
    }
}