using MediatR;
using SchoolPortal.Domain.Entities;
using SchoolPortal.Domain.SeedWork;

namespace SchoolPortal.Application.CQRS.Commands;

public record DepartmentCommand: IRequest
{
    public string Name { get; set; } = default!;
}

public class DepartmentCommandHandler: IRequestHandler<DepartmentCommand>
{
    private readonly IGenericRepository<Department> _departmentRepository;

    public DepartmentCommandHandler(IGenericRepository<Department> departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task Handle(DepartmentCommand command, CancellationToken cancellationToken)
    {
        var newDepartment = new Department(command.Name);
        newDepartment = await _departmentRepository.AddAsync(newDepartment);

        newDepartment.EnqueuAddDepartmentEvent();
        await _departmentRepository.UnitOfWork.SaveAsync();
    }
}
