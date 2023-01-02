using Core.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
{
    public GenreRepository(RepositoryContext context) : base(context)
    { }

    public async Task<IEnumerable<Genre>> GetAllGenresAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(genre => genre.Name)
        .ToListAsync();

    public async Task<Genre?> GetGenreAsync(string genreId, bool trackChanges) =>
        await FindByCondition(Genre => Genre.GenreId.Equals(genreId), trackChanges)
        .Include(b => b.Books)
        .SingleOrDefaultAsync();
}