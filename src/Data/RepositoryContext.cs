using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Data.Configuration;
using Data.Identity;
using Core.Entities;

namespace Data;

public class RepositoryContext : IdentityDbContext<User>
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new BookAuthorConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.Entity<Book>()
            .HasIndex(i => i.ISBN)
            .IsUnique();
        modelBuilder.Entity<Book>()
            .HasOne(g => g.Genre)
            .WithMany(c => c.Books)
            .HasForeignKey(f => f.GenreId);
    }
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Book> Books => Set<Book>();
}

