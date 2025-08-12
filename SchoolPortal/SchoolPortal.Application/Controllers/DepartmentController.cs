using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolPortal.Application.CQRS.Queries;

namespace SchoolPortal.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    DepartmentQuery _departmentQuery;

    public DepartmentController(DepartmentQuery departmentQuery)
    {
        _departmentQuery = departmentQuery;
    }

    [HttpGet("/departments")]
    public async Task<IActionResult> Departments()
    {
        var departments = await _departmentQuery.GetDepartments();
        return Ok(departments);
    }
}
