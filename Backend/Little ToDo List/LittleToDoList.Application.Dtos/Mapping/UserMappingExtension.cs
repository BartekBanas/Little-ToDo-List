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
    
    public static User ToEntity(this UserCreateDto dto)
    {
        return new User(dto.Name, dto.Password)
        {
            Name = dto.Name,
            Password = dto.Password
        };
    }
}