﻿using System.ComponentModel.DataAnnotations;
using LittleToDoList.Business.Abstractions;

namespace LittleToDoList.Business.Entities;

public class User : Entity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public DateTime CreationDate { get; set; }

    public User()
    {
    }

    public User(Guid id, string name, string passwordHash)
    {
        Id = id;
        Name = name;
        PasswordHash = passwordHash;
    }
}