using Data.Interfaces;
using Data.Repository;


namespace Data;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IBookRepository> _bookRepository;
    private readonly Lazy<IAuthorRepository> _authorRepository;
    private readonly Lazy<IGenreRepository> _genreRepository;

    public RepositoryManager(RepositoryContext context)
    {
        _repositoryContext = context;
        _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_repositoryContext));
        _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(_repositoryContext));
        _genreRepository = new Lazy<IGenreRepository>(() => new GenreRepository(_repositoryContext));
    }

    public IBookRepository bookRepository => _bookRepository.Value;
    public IAuthorRepository authorRepository => _authorRepository.Value;
    public IGenreRepository genreRepository => _genreRepository.Value;

    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}