namespace Data.Interfaces;

public interface IRepositoryManager
{
    IBookRepository bookRepository { get; }
    IAuthorRepository authorRepository { get; }
    IGenreRepository genreRepository { get; }
    Task SaveAsync();
}
