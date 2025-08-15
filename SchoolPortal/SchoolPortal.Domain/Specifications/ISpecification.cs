using SchoolPortal.Domain.SeedWork;
using System.Linq.Expressions;

namespace SchoolPortal.Domain.Specifications;

public interface ISpecification<T> where T : Entity 
{
    Expression<Func<T, bool>> Critera { get; } // to be used for filtering
    List<Expression<Func<T, object>>> Includes { get; } // for including related entities
}
