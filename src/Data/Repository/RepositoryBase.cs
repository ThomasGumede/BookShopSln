using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repository;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected RepositoryContext _context;

    public RepositoryBase(RepositoryContext ctx) =>
        _context = ctx;

    public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges ?
          _context.Set<T>()
            .AsNoTracking() :
          _context.Set<T>();

    public T? FindById(int id) => _context.Set<T>().Find(id);
    public T? FindById(string id) => _context.Set<T>().Find(id);

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
        !trackChanges ?
          _context.Set<T>()
            .Where(expression)
            .AsNoTracking() :
          _context.Set<T>()
            .Where(expression);

    public void Create(T entity) => _context.Set<T>().Add(entity);

    public void Update(T entity) => _context.Set<T>().Update(entity);

    public void Delete(T entity) => _context.Set<T>().Remove(entity);
}
