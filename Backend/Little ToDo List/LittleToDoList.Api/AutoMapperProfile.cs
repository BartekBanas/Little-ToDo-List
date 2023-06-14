﻿using LittleToDoList.Application.Dto;
using LittleToDoList.Business.Entities;
using AutoMapper;

namespace LittleToDoList.Api;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ToDo, ToDoItemDto>();
        CreateMap<User, UserDto>();
    }
}