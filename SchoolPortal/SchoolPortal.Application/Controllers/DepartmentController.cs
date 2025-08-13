using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolPortal.Application.CQRS.Commands;
using SchoolPortal.Application.CQRS.Queries;

namespace SchoolPortal.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    readonly ISender _sender;
    readonly DepartmentQuery _departmentQuery;
    readonly ILogger<DepartmentController> _logger;

    public DepartmentController
    (
        ISender sender,
        DepartmentQuery departmentQuery, 
        ILogger<DepartmentController> logger
    )
    {
        _sender = sender;
        _logger = logger;
        _departmentQuery = departmentQuery;
    }

    [HttpGet("/departments")]
    public async Task<IActionResult> Departments() // TODO: change this to IResult
    {
        var departments = await _departmentQuery.GetDepartments();
        return Ok(departments);
    }

    [HttpPost]
    public async Task<IResult> CreateDepartment(DepartmentCommand command)
    {
        await _sender.Send(command);
        return Results.NoContent();
    }
}
