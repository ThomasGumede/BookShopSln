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
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public BookService(IRepositoryManager _repo, IMapper map, ILoggerManager log)
    {
        _context = _repo;
        _logger = log;
        _mapper = map;
    }

    public async Task<IEnumerable<BookDto>> GetAllBooksAsync(bool trackChanges)
    {
        var books = await _context.bookRepository.GetAllAsync(trackChanges);

        var bookDto = _mapper.Map<IEnumerable<BookDto>>(books);
        return bookDto;
    }

    public async Task<(IEnumerable<BookDto> books, MetaData metaData)> GetAllBooksAsync(RequestParameters requestParameters, bool trackChanges)
    {
        var books = await _context.bookRepository.GetAllAsync(requestParameters, trackChanges);
        var bookDto = _mapper.Map<IEnumerable<BookDto>>(books);

        return (books: bookDto, metaData: books.MetaData);
    }

    public async Task<IEnumerable<BookDto>> GetRandomBooksAsync(bool trackChanges)
    {
        var books = await _context.bookRepository.GetRandomAsync(trackChanges);
        var bookdtos = _mapper.Map<IEnumerable<BookDto>>(books);

        return bookdtos;
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
        _context.bookRepository.Create(book);

        await _context.SaveAsync();

        return bookdto;
    }

    public async Task DeleteBookAsync(int bookId, bool trackChanges)
    {
        var book = await GetBookAndCheckIfItExists(bookId, trackChanges);

        _context.bookRepository.Delete(book);
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
