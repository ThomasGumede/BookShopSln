using Data.DTOs;

namespace BookShop.Models
{
    public record class BookDetailViewModel
    {
        public BookDetailsDto Book { get; set; } = null!;

        public IEnumerable<BookDto> SimilarBooks { get; set; } = null!;
    }
}