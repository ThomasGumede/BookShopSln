using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Data.Interfaces;

namespace Data.Repository;

public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
{
    public AuthorRepository(RepositoryContext context) : base(context)
    { }

    public async Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .Include(a => a.Books)
        .OrderBy(author => author.FirstName)
        .ToListAsync();

    public async Task<Author?> GetAuthorByIdAsync(int AuthorId, bool trackChanges) =>
        await FindByCondition(author => author.AuthorId.Equals(AuthorId), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateAuthor(Author author) => Create(author);

    public void DeleteAuthor(Author author) => Delete(author);
}

