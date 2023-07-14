using System.ComponentModel.DataAnnotations;
using LittleToDoList.Business.Abstractions;

namespace LittleToDoList.Business.Entities;

public class User : Entity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateTime CreationDate { get; set; }

    public User()
    {
    }

    public User(string name, string password)
    {
        Name = name;
        Password = password;
        CreationDate = DateTime.Now;
    }
}