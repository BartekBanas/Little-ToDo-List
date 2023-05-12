namespace LittleToDoList.Application.Dto;

public class ToDoDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public string Description { get; set; }
    public bool IsDone { get; set; }
}