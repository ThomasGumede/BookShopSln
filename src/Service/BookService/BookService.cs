using Core.Exceptions;
using Data.Interfaces;
using Data.Request;
using Data.DTOs;
using Service.Interfaces;
using Core.Entities;
using AutoMapper;

namespace Service;

public class BookService : IBookService
{
    private readonly IRepositoryManager _context;
    // private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public BookService(IRepositoryManager _repo, IMapper map)
    {
        _context = _repo;
        // _logger = log;
        _mapper = map;
    }

    public async Task<(IEnumerable<BookDto> bookDtos, MetaData metaData)> GetAllBooksAsync(bool trackChanges, int pageNumber = 1, int pageSize = 5)
    {
        var books = await _context.bookRepository.GetAllAsync(trackChanges, pageNumber, pageSize);
        var data = books.MetaData.CurrentPage;
        var bookDto = _mapper.Map<IEnumerable<BookDto>>(books);
        return (bookDtos: bookDto, metaData: books.MetaData);
    }

    public async Task<(IEnumerable<BookDto> bookDtos, MetaData metaData)> GetAllBooksAsync(RequestParameters requestParameters, bool trackChanges)
    {
        var books = await _context.bookRepository.GetAllAsync(requestParameters, trackChanges);
        var bookDto = _mapper.Map<IEnumerable<BookDto>>(books);

        return (bookDtos: bookDto, metaData: books.MetaData);
    }

    public async Task<BookDetailsDto> GetBookDetailsAsync(int bookId, bool trackChanges)
    {
        var book = await GetBookAndCheckIfItExists(bookId, trackChanges);
        var BookDetailsDto = _mapper.Map<BookDetailsDto>(book);

        return BookDetailsDto;
    }

    public async Task<BookDetailsDto> AddBookAsync(BookDetailsDto bookdto)
    {
        var book = _mapper.Map<Book>(bookdto);
        _context.bookRepository.CreateBook(book);

        await _context.SaveAsync();

        return bookdto;
    }

    public async Task DeleteBookAsync(int bookId, bool trackChanges)
    {
        var book = await GetBookAndCheckIfItExists(bookId, trackChanges);

        _context.bookRepository.DeleteBook(book);
        await _context.SaveAsync();

    }

    private async Task<Book> GetBookAndCheckIfItExists(int id, bool trackChanges)
    {
        var book = await _context.bookRepository.GetBookByIdAsync(id, trackChanges);
        if (book is null)
            throw new BookNotFoundException(id);

        return book;
    }


}
