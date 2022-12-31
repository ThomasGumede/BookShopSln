using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Data.Configuration;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasData(
            new { GenreId = "novel", Name = "Novel" },
            new { GenreId = "memoir", Name = "Memoir" },
            new { GenreId = "mystery", Name = "Mystery" },
            new { GenreId = "scifi", Name = "Science Fiction" },
            new { GenreId = "history", Name = "History" },
            new { GenreId = "poetry", Name = "Poetry" },
            new { GenreId = "humor", Name = "Humor" },
            new { GenreId = "politics", Name = "Politics" },
            new { GenreId = "comic", Name = "Comic" },
            new { GenreId = "fantasy", Name = "Fantasy" }
        );
    }
}
