using Data.DTOs;

namespace BookShop.Models;

public record class HomeViewModel
{
    public IEnumerable<BookDto> Books { get; set; } = null!;
    public IEnumerable<BookDto> RandomBooks { get; set; } = null!;
    public IEnumerable<AuthorDto> Authors { get; set; } = null!;
    public IEnumerable<GenreDto> Genres { get; set; } = null!;
}
