using MediatR;
using SchoolPortal.Domain.Entities;
using SchoolPortal.Domain.SeedWork;

namespace SchoolPortal.Application.CQRS.Commands;

public class DepartmentCommand: IRequest
{
    public string Name { get; }

    public DepartmentCommand(string name)
    {
        Name = name;
    }
}

public class DepartmentCommandHandler: IRequestHandler<DepartmentCommand>
{
    private readonly IGenericRepository<Department> _departmentRepo;

    public DepartmentCommandHandler(IGenericRepository<Department> departmentRepo)
    {
        _departmentRepo = departmentRepo;
    }

    public async Task Handle(DepartmentCommand command, CancellationToken cancellationToken)
    {
        await _departmentRepo.AddAsync(new Department("Finance"));
        await _departmentRepo.UnitOfWork.SaveAsync();
    }
}