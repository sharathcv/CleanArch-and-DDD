using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolPortal.Domain.Entities;
using SchoolPortal.Domain.Entities.StudentAggregate;
using SchoolPortal.Domain.SeedWork;
using SchoolPortal.Infrastructure.Extensions;
using System.Reflection;

namespace SchoolPortal.Infrastructure;

public class SchoolContext : DbContext, IUnitOfWork
{
    private readonly IMediator _mediator;

    public SchoolContext(DbContextOptions<SchoolContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }

    // DbSets for each entity in the domain model   
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Todo> Todos { get; set; }

    public async Task<bool> SaveAsync(CancellationToken cancellationToken = default)
    {
        await base.SaveChangesAsync(cancellationToken);

        // After a successful save, dispatch domain events
        await _mediator.DispatchDomainEventsAsync(this);

        return true;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TODO: Move below ignore calls to Entity Configuration files for each of the entity
        modelBuilder.Entity<Student>(e => e.Ignore(x => x.DomainEvents));
        modelBuilder.Entity<Department>(e => e.Ignore(x => x.DomainEvents));
        modelBuilder.Entity<Todo>(e => e.Ignore(x => x.DomainEvents));
        modelBuilder.Entity<Course>(e => e.Ignore(x => x.DomainEvents));

        // Separate configuration file will be there for each entity which will be picked up from assembly
        // (refer to folder "EntityConfigurations")
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
