using SchoolPortal.Domain.Specifications;
using System.Linq.Expressions;

namespace SchoolPortal.Domain.SeedWork;

public interface IGenericRepository<T> where T: Entity, IAggregateRoot
{
    IEnumerable<T> Specify(ISpecification<T> spec);
    //IEnumerable<T> Specify2(ISpecification<T> spec);
    IUnitOfWork UnitOfWork { get; }
    Task<T> AddAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T> GetByIdAsync(int Id);
    Task<T?> GetAsync(Expression<Func<T,bool>> predicate);
    //Task<T> GetAsync(ISpecification<T> spec);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task UpdateAsync(T entity);
}