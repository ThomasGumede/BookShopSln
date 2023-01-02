using Service.Interfaces;
using Data.Interfaces;
using AutoMapper;

namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IBookService> _bookService;
    private readonly Lazy<IAuthorService> _authorService;
    private readonly Lazy<IGenreService> _genreService;

    public ServiceManager(IMapper mapper,  IRepositoryManager repo, ILoggerManager logger)
    {
        _bookService = new Lazy<IBookService>(() => new BookService(repo, mapper, logger));
        _authorService = new Lazy<IAuthorService>(() => new AuthorService(repo, mapper));
        _genreService = new Lazy<IGenreService>(() => new GenreService(repo, mapper));
    }

    public IBookService bookService => _bookService.Value;
    public IAuthorService authorService => _authorService.Value;
    public IGenreService genreService => _genreService.Value;
}
