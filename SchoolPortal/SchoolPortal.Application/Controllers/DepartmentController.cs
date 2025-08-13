using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolPortal.Application.CQRS.Queries;

namespace SchoolPortal.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    readonly ILogger<DepartmentController> _logger;
    readonly DepartmentQuery _departmentQuery;

    public DepartmentController
    (
        DepartmentQuery departmentQuery, 
        ILogger<DepartmentController> logger
    )
    {
        _logger = logger;
        _departmentQuery = departmentQuery;
    }

    [HttpGet("/departments")]
    public async Task<IActionResult> Departments()
    {
        var departments = await _departmentQuery.GetDepartments();
        return Ok(departments);
    }
}
