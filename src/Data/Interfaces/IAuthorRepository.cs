using Core.Entities;

namespace Data.Interfaces;
public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges);
    Task<Author?> GetAuthorByIdAsync(int AuthorId, bool trackChanges);
    void CreateAuthor(Author author);
    void DeleteAuthor(Author author);
}
