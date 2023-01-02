using Data.DTOs;
using Data.Request;

namespace BookShop.Models
{
    public record class BookViewModel
    {
        public MetaData Metadata { get; set; } = null!;
        public IEnumerable<BookDto> Books { get; set; } = null!;
        public IEnumerable<GenreDto> Genres { get; set; } = null!;

    }
}