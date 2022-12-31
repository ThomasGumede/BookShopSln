using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.DTOs;

public record class AuthorDto
{
    public int AuthorId { get; set; }
    public string? AuthorImageUri { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? BookCount { get; set; }
}

public record class AuthorDetailsDto(int AuthorId, string? AuthorImageUri, string FirstName, string LastName, int BookCount)
{
    public IEnumerable<BookDto>? Books { get; set; }
}
