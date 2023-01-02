using Core.Entities;

namespace Data.Interfaces;
public interface IAuthorRepository : IRepositoryBase<Author>
{
    Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges);
    Task<Author?> GetAuthorByIdAsync(int AuthorId, bool trackChanges);
}
