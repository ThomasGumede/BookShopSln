using Core.Entities;
using Data.Request;

namespace Data.Interfaces;
public interface IBookRepository
{
    Task<PagedList<Book>> GetAllAsync(RequestParameters requestParameters, bool trackChanges);
    Task<PagedList<Book>> GetAllAsync(bool trackChanges, int pageNumber, int pageSize);
    Task<Book?> GetBookByIdAsync(int BookId, bool trackChanges);
    void CreateBook(Book book);
    void DeleteBook(Book book);
}
