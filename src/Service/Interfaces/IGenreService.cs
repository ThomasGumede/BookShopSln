using Data.DTOs;

namespace Service.Interfaces;
public interface IGenreService
{
    Task<IEnumerable<GenreDto>> AllGenresAsync(bool trackChanges);
}
