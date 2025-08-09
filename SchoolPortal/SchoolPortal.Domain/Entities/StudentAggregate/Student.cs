using SchoolPortal.Domain.SeedWork;

namespace SchoolPortal.Domain.Entities.StudentAggregate
{
    public class Student: Entity, IAggregateRoot
    {
        public Student
        (
            string firstName, 
            string lastName, 
            string email, 
            string password,
            int age,
            string gender
        )
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Age = age;
            Gender = gender;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public int Age { get; private set; }
        public string Gender { get; private set; }

        // This is an owned or a navigation property
        public Address Address { get; private set; }

        // Keep the list private and expose a readonly collection representing the list
        private readonly List<StudentCourse> _studentCourses = [];
        public IReadOnlyCollection<StudentCourse> StudentCourses => _studentCourses;

        // Behaviours
        public void AddAddress(string state, string country, string street, string city)
        {
            Address = new Address(state, country, street, city);
        }

        public void EnrollCourse(int studentId, int courseId)
        {
            if (!StudentCourses.Any(s => studentId == s.StudentId && s.CourseId == courseId))
            {
                //enroll the student for course 
                var studentCourse = new StudentCourse(studentId, courseId);
                _studentCourses.Add(studentCourse);
                //studentCourse.AddDomainEvents(new CourseEnrolledEvent(studentId, courseId)); //publish domain event
            }
        }

        public bool HasEnrolled(int studentId, int courseId)
        {
            return StudentCourses.Any(s => studentId == s.StudentId && s.CourseId == courseId);
        }
    }
}
