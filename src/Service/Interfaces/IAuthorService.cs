using Data.DTOs;

namespace Service.Interfaces;

public interface IAuthorService
{
    Task<IEnumerable<AuthorDto>> AllAuthorsAsync(bool trackChanges);
}
