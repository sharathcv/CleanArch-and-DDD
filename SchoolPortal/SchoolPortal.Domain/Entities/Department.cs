using SchoolPortal.Domain.DomainEvents;
using SchoolPortal.Domain.SeedWork;

namespace SchoolPortal.Domain.Entities;

public class Department: Entity, IAggregateRoot    
{
    public Department(string name)
    {
        Name = name;
        IsActive = true;
    }

    public string Name { get; private set; }
    public bool IsActive { get; private set; }

    // Behaviours are listed below
    public void EnqueuAddDepartmentEvent()
    { 
        var departmentCreatedEvent = new DepartmentDomainEvent(this);
        AddDomainEvent(departmentCreatedEvent);
    }
}
