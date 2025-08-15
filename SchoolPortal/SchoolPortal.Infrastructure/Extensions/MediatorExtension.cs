using MediatR;
using SchoolPortal.Domain.SeedWork;

namespace SchoolPortal.Infrastructure.Extensions;

public static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, SchoolContext context)
    {
        // Fetch all entities that have domain events
        var entitiesWithEvents = context.ChangeTracker
                                        .Entries<Entity>()
                                        .Where(e => e.Entity.DomainEvents != null 
                                                    && e.Entity.DomainEvents.Any());

        // Get the list of domain events
        var domainEvents = entitiesWithEvents.SelectMany(e => e.Entity.DomainEvents)
                                             .ToList();

        // Clear the domain events for all the entities
        entitiesWithEvents.ToList().ForEach(e => e.Entity.ClearDomainEvents());

        // Dispatch each domain event
        foreach (INotification domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);
        }
    }
}
