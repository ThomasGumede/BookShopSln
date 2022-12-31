using Data.DTOs;
using Data.Request;

namespace Service.Interfaces;

public interface IBookService
{
    Task<(IEnumerable<BookDto> bookDtos, MetaData metaData)> GetAllBooksAsync(RequestParameters requestParameters, bool trackChanges);
    Task<(IEnumerable<BookDto> bookDtos, MetaData metaData)> GetAllBooksAsync(bool trackChanges, int pageNumber, int pageSize);
    Task<BookDetailsDto> GetBookDetailsAsync(int bookId, bool trackChanges);
    Task<BookDetailsDto> AddBookAsync(BookDetailsDto bookdto);
    Task DeleteBookAsync(int bookId, bool trackChanges);
}
