using SchoolPortal.Domain.SeedWork;

namespace SchoolPortal.Domain.Entities;

public class Todo: Entity, IAggregateRoot
{
    public Todo(int studentId, string name, string description)
    {
        StudentId = studentId;
        Name = name;
        Description = description;
    }

    public int StudentId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsActive { get; private set; }
    public bool IsCompleted { get; private set; }
    public DateTime? DateCompleted { get; private set; }

    // Behaviours are listed below
    public void CompleteTodo(DateTime dateCompleted, Todo todo)
    {
        todo.IsCompleted = true;
        todo.DateCompleted = dateCompleted;
        todo.IsActive = true;
    }

    public void CompleteTodo() { }
}
