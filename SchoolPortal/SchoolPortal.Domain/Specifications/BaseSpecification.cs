using SchoolPortal.Domain.SeedWork;
using System.Linq.Expressions;

namespace SchoolPortal.Domain.Specifications;

public class BaseSpecification<T> : ISpecification<T> where T : Entity
{
    public Expression<Func<T, bool>> Critera { get; }
    public List<Expression<Func<T, object>>> Includes { get; } = [];

    public BaseSpecification(Expression<Func<T, bool>> critera)
    {
        Critera = critera;
    }

    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }
}
