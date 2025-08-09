using SchoolPortal.Domain.SeedWork;

namespace SchoolPortal.Domain.Entities;

public class Department: Entity, IAggregateRoot    
{
    public Department(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
    public bool IsActive { get; private set; } = true;
}