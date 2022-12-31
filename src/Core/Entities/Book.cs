using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Book
{
    public Book() => Authors = new HashSet<Author>();
    public int BookId { get; set; }
    [Required(ErrorMessage = "Book title is required")]
    public string Title { get; set; } = null!;
    public string? BookImageUri { get; set; }
    public string? Description { get; set; }

    [Range(1.0, 1000000.0, ErrorMessage = "Price must be 1 or more.")]
    public double Price { get; set; }
    public string ISBN { get; set; } = null!;
    public string? Edition { get; set; }
    public string Language { get; set; } = null!;
    [Required(ErrorMessage = "Book pages number is required")]
    public int Pages { get; set; }
    public DateTime? PublishDate { get; set; } = DateTime.Today;
    public string? GenreId { get; set; }
    public Genre? Genre { get; set; }

    public ICollection<Author> Authors { get; set; }
}
