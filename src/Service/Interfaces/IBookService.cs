using Data.DTOs;
using Data.Request;

namespace Service.Interfaces;

public interface IBookService
{
    Task<(IEnumerable<BookDto> books, MetaData metaData)> GetAllBooksAsync(RequestParameters requestParameters, bool trackChanges);
    Task<IEnumerable<BookDto>> GetAllBooksAsync(bool trackChanges);
    Task<IEnumerable<BookDto>> GetRandomBooksAsync(bool trackChanges);
    Task<BookDetailsDto> GetBookDetailsAsync(int bookId, bool trackChanges);
    Task<BookDetailsDto> AddBookAsync(BookDetailsDto bookdto);
    Task DeleteBookAsync(int bookId, bool trackChanges);
}
