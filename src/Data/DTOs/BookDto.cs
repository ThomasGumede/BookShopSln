using Data.Request;

namespace Data.DTOs;

public record class BookDto(int bookId, string Title, string? BookImageUri, double Price, string? Description);

public record class BookDetailsDto
{
    public int BookId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? BookImageUri { get; set; }

    public double Price { get; set; }

    public string? Publisher { get; set; }

    public string? ISBN { get; set; }

    public string? Eddition { get; set; }

    public DateTime PublicationDate { get; set; }

    public string? Language { get; set; }

    public int Pages { get; set; }

    public string? GenreId { get; set; }

    public GenreDto? Genre { get; set; }

    public IEnumerable<AuthorDto>? Authors { get; set; }
}