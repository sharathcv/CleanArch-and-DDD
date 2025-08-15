using SchoolPortal.Application.Responses;
using SchoolPortal.Domain.Entities;
using SchoolPortal.Domain.SeedWork;
using SchoolPortal.Domain.Specifications;

namespace SchoolPortal.Application.CQRS.Queries;

public class DepartmentQuery
{
    private readonly IGenericRepository<Department> _departmentRepo;

    public DepartmentQuery(IGenericRepository<Department> departmentRepo)
    {
        _departmentRepo = departmentRepo;
    }

    public async Task<IEnumerable<DepartmentResponse>> GetDepartments()
    {
        // Base specification can also be used directly
        //var activeDepartments = _departmentRepo.Specify(new BaseSpecification<Department>(d => d.IsActive));

        // By using specific implementation
        var activeDepartments = _departmentRepo.Specify(new GetActiveDepartments());
        return activeDepartments.Select(d => new DepartmentResponse { Name = d.Name });
    }
}
