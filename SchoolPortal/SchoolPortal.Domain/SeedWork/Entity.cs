using MediatR;

namespace SchoolPortal.Domain.SeedWork;

public class Entity
{
    public int Id { get; private set; }
    public DateTime DateCreated { get; private set; } = DateTime.UtcNow;

    private List<INotification> _domainEvents = [];

    // This will be ignored in the OnModelCreating for all entities
    public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(INotification domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(INotification domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}