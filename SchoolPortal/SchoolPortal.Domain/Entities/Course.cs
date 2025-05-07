using SchoolPortal.Domain.SeedWork;

namespace SchoolPortal.Domain.Entities
{
    public class Course: Entity, IAggregateRoot
    {
        public Course()
        {
            
        }

        public int DepartmentId { get; private set; }

    }
}
