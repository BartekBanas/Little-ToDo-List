﻿namespace LittleToDoList.Application.Dto;

public class UserCreateDto
{
    public string Name { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
}