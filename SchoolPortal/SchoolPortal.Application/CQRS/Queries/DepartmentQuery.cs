using SchoolPortal.Application.Responses;
using SchoolPortal.Domain.Entities;
using SchoolPortal.Domain.SeedWork;

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
        var departments = await _departmentRepo.GetAllAsync();
        return departments.Select(d => new DepartmentResponse { Name = d.Name });
    }
}
