using SchoolPortal.Domain.Entities;

namespace SchoolPortal.Infrastructure;

public static class SchoolContextSeed
{
    public static async Task SeedAsync(SchoolContext context)
    {
        try 
        {
            int departmentId = 0;

            if (!context.Departments.Any())
            {
                var department = context.Departments.Add(new Department("Computer Science"));
                await context.SaveChangesAsync();
                departmentId = department.Entity.Id;
            }

            if (!context.Courses.Any())
            {
                context.Courses.AddRange(new List<Course>
                {
                    { new Course(departmentId, "Data Analytics") },
                    { new Course(departmentId, "Software Engineering") }
                });

                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            // Log the exception (consider using a logging framework)
            Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
        }
    }
}
