using Microsoft.EntityFrameworkCore;
using SchoolPortal.Domain.SeedWork;
using System.Linq.Expressions;

namespace SchoolPortal.Infrastructure.Repository;

public class GenericRepository<T>: IGenericRepository<T> where T: Entity, IAggregateRoot
{
    protected readonly SchoolContext _context;
    internal DbSet<T> _set;

    public IUnitOfWork UnitOfWork => _context;

    public GenericRepository(SchoolContext context)
    {
        _context = context;
        _set = _context.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _set.AddAsync(entity);
        return entity;
    }

    public Task DeleteAsync(T entity)
    {
        _set.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
    {
        var data = await _set.FirstOrDefaultAsync(predicate);
        return data;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _set.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var data = await _set.FindAsync(id);
        if (data == null)
        {
            throw new KeyNotFoundException($"Entity of type {typeof(T).Name} with ID {id} not found.");
        }

        return data;
    }

    public Task UpdateAsync(T entity)
    {
        _set.Update(entity);
        return Task.CompletedTask;
    }
}
