using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolPortal.Domain.Entities.StudentAggregate;

namespace SchoolPortal.Infrastructure.EntityConfigurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Student.StudentCourses));
            navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.OwnsOne(student => student.Address, address =>
            {
                address.WithOwner();
                address.Property(a => a.City).HasColumnName("City").IsRequired();
                address.Property(a => a.Street).HasColumnName("Street").IsRequired();
                address.Property(a => a.Country).HasColumnName("Country").IsRequired();
                address.Property(a => a.State).HasColumnName("State").HasMaxLength(60).IsRequired();
            });

            builder.Navigation(s => s.Address).IsRequired();
        }
    }
}
