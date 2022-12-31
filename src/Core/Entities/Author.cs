using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Author
{
    public Author() => Books = new HashSet<Book>();

    // primary key property
    public int AuthorId { get; set; }

    public string? AuthorImageUri { get; set; }

    [Required(ErrorMessage = "Please enter a first name.")]
    [MaxLength(200)]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a last name.")]
    [MaxLength(200)]
    public string LastName { get; set; } = string.Empty;

    // read-only property
    public string FullName => $"{FirstName} {LastName}";

    // navigation property
    public ICollection<Book> Books { get; set; }
}
