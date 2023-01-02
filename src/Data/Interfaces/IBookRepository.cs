using Core.Entities;
using Data.Request;

namespace Data.Interfaces;
public interface IBookRepository : IRepositoryBase<Book>
{
    Task<PagedList<Book>> GetAllAsync(RequestParameters requestParameters, bool trackChanges);
    Task<IEnumerable<Book>> GetAllAsync(bool trackChanges);
    Task<IEnumerable<Book>> GetRandomAsync(bool trackChanges);
    Task<Book?> GetBookByIdAsync(int BookId, bool trackChanges);
}
