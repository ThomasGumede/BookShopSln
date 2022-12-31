using Core.Entities;

namespace Data.Interfaces;

public interface IGenreRepository
{
    Task<IEnumerable<Genre>> GetAllGenresAsync(bool trackChanges);
    Task<Genre?> GetGenreAsync(string GenreId, bool trackChanges);
    void CreateGenre(Genre genre);
    void DeleteGenre(Genre genre);
}
