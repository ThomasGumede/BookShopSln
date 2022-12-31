using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IRepositoryBase<T> where T : class
{
    IQueryable<T> FindAll(bool trackChanges);
    T? FindById(int id);
    T? FindById(string id);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}
