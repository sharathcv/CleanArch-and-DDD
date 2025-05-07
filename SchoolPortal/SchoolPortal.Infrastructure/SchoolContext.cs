using Microsoft.EntityFrameworkCore;
using SchoolPortal.Domain.Entities;
using SchoolPortal.Domain.Entities.StudentAggregate;
using SchoolPortal.Domain.SeedWork;
using System.Reflection;

namespace SchoolPortal.Infrastructure
{
    public class SchoolContext : DbContext, IUnitOfWork
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Todo> Todo { get; set; }

        public async Task<bool> SaveAsync(CancellationToken cancellationToken = default)
        {
            await base.SaveChangesAsync(cancellationToken);
            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Separate configuration file will be there for each entity which we will pick up from assembly
            // refer to folder "EntityConfigurations"
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
