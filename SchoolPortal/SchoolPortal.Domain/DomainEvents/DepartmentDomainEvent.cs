using MediatR;
using SchoolPortal.Domain.Entities;

namespace SchoolPortal.Domain.DomainEvents;

public class DepartmentDomainEvent: INotification
{
    public Department Department { get; }

    public DepartmentDomainEvent(Department department)
    {
        Department = department;
    }
}
