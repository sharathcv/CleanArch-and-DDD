using Microsoft.EntityFrameworkCore;
using SchoolPortal.Domain.SeedWork;

namespace SchoolPortal.Infrastructure
{
    public class SchoolContext : DbContext, IUnitOfWork
    {
    }
}
