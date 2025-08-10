using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolPortal.Domain.Entities;
using SchoolPortal.Domain.Entities.StudentAggregate;
using SchoolPortal.Domain.SeedWork;
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
    public DbSet<Student> Student { get; set; }
    public DbSet<Course> Course { get; set; }
    public DbSet<StudentCourse> StudentCourse { get; set; }
    public DbSet<Department> Department { get; set; }
    public DbSet<Todo> Todo { get; set; }

    public async Task<bool> SaveAsync(CancellationToken cancellationToken = default)
    {
        await base.SaveChangesAsync(cancellationToken);

        // After a successful save, dispatch domain events
        await _mediator.Publish(this);

        return true;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Separate configuration file will be there for each entity which will be picked up from assembly
        // (refer to folder "EntityConfigurations")
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
