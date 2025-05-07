using SchoolPortal.Domain.SeedWork;

namespace SchoolPortal.Domain.Entities
{
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
        public DateTime? DateCompeted { get; private set; }

        // Behaviours
        public void CompleteTodo(DateTime dateCompleted, Todo todo)
        {
            todo.IsCompleted = true;
            todo.DateCompeted = dateCompleted;
            todo.IsActive = true;
        }

        public void CompleteTodo() { }
    }
}
