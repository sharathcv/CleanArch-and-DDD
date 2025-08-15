using SchoolPortal.Domain.Entities;

namespace SchoolPortal.Domain.Specifications;

public class GetActiveDepartments: BaseSpecification<Department>
{
    public GetActiveDepartments() : base(d => d.IsActive)
    {
        // If there are related classes, they can be included as shown below
        //AddInclude(d => d.Courses);
        //AddInclude(d => d.Students);
        //AddOrderBy(d => d.Name);
        //ApplyPaging(0, 10); // Example: limit to 10 results
    }
}
