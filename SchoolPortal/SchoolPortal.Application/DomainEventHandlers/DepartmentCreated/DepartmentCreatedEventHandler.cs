using MediatR;
using SchoolPortal.Domain.DomainEvents;
using SchoolPortal.Domain.Entities;
using SchoolPortal.Domain.SeedWork;

namespace SchoolPortal.Application.DomainEventHandlers.DepartmentCreated;

public class DepartmentCreatedEventHandler: INotificationHandler<DepartmentDomainEvent>
{
    readonly IGenericRepository<Todo> _todoRepository;

    public DepartmentCreatedEventHandler(IGenericRepository<Todo> todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task Handle(DepartmentDomainEvent notification, CancellationToken cancellationToken)
    {
        // Create a new Todo item for the newly created department
        var todo = new Todo(
        
            1, // TODO: Change this to a valid StudentId
            $"Department created - {notification.Department.Id}",
            "Testing domain events"
        );

        await _todoRepository.AddAsync(todo);
        await _todoRepository.UnitOfWork.SaveAsync(cancellationToken);
    }
}
