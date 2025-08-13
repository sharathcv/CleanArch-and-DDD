namespace SchoolPortal.Domain.DomainEvents
{
    public class CourseEnrolledEvent 
    {
        public int StudentId { get; }
        public int CourseId { get; }

        public CourseEnrolledEvent(int studentId, int courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
        }
    }
}