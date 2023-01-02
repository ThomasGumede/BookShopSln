using Core.Entities;

namespace Data.Interfaces;

public interface IGenreRepository : IRepositoryBase<Genre>
{
    Task<IEnumerable<Genre>> GetAllGenresAsync(bool trackChanges);
    Task<Genre?> GetGenreAsync(string GenreId, bool trackChanges);
}
