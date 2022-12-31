using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Data.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        string descr = @"Lorem ipsum dolor sit amet consectetur adipisicing elit.
                        Nobis reiciendis debitis corporis tempore consequuntur illo blanditiis, 
                        exercitationem temporibus.Necessitatibus accusantium cupiditate in vero unde provident modi 
                        eveniet commodi sit dolorem? Natus totam ab, corporis in aspernatur est porro optio nostrum, 
                        tenetur placeat aut asperiores numquam dicta, nemo veritatis doloribus eveniet ? 
                        ";
        builder.HasData(
            new { BookId = 1, Title = "1776", BookImageUri = "images/books/history/bk1.jpeg", Description = descr, GenreId = "history", Price = 18.00, ISBN = "226TW5678901", Pages = 865, Language = "English" },
            new { BookId = 2, Title = "1984", BookImageUri = "images/books/scifi/bk.jpeg", Description = descr, GenreId = "scifi", Price = 5.50, ISBN = "2134TR123YT", Pages = 405, Language = "English" },
            new { BookId = 3, Title = "And Then There Were None", BookImageUri = "images/books/mystery/bk1.jpeg", Description = descr, GenreId = "mystery", Price = 4.50, ISBN = "67DF672134DX", Pages = 563, Language = "English" },
            new { BookId = 4, Title = "Band of Brothers", BookImageUri = "images/books/history/bk2.jpeg", Description = descr, GenreId = "history", Price = 11.50, ISBN = "456GHQ34567", Pages = 654, Language = "English" },
            new { BookId = 5, Title = "Beloved", BookImageUri = "images/books/novel/bk5.jpeg", Description = descr, GenreId = "novel", Price = 10.99, ISBN = "785GHQ2134", Pages = 867, Language = "English" },
            new { BookId = 6, Title = "Between the World and Me", BookImageUri = "images/books/memoir/bk3.jpg", Description = descr, GenreId = "memoir", Price = 13.50, ISBN = "906754RT562", Pages = 765, Language = "Spanish" },
            new { BookId = 7, Title = "Bossypants", BookImageUri = "images/books/memoir/bk2.jpeg", Description = descr, GenreId = "memoir", Price = 4.25, ISBN = "823THG1254R", Pages = 876, Language = "Spanish" },
            new { BookId = 8, Title = "Brave New World", BookImageUri = "images/books/scifi/bk29.jpg", Description = descr, GenreId = "scifi", Price = 16.25, ISBN = "098TGF1267F", Pages = 1678, Language = "Zulu" },
            new { BookId = 9, Title = "D-Day", BookImageUri = "images/books/history/bk3.jpeg", Description = descr, GenreId = "history", Price = 15.00, ISBN = "651DFT6342", Pages = 1245, Language = "Zulu" },
            new { BookId = 10, Title = "Down and Out in Paris and London", BookImageUri = "images/books/memoir/bk1.jpeg", Description = descr, GenreId = "memoir", Price = 12.50, ISBN = "2345TGS234", Pages = 678, Language = "Zulu" },
            new { BookId = 11, Title = "Dune", BookImageUri = "images/books/scifi/bk8.jpeg", Description = descr, GenreId = "scifi", Price = 8.75, ISBN = "1234RDS6721X", Pages = 330, Language = "Dutch" },
            new { BookId = 12, Title = "Emma", BookImageUri = "images/books/novel/emma.jpg", Description = descr, GenreId = "novel", Price = 9.00, ISBN = "76TS5423HJ", Pages = 205, Language = "Dutch" },
            new { BookId = 13, Title = "Frankenstein", BookImageUri = "images/books/scifi/bk6.jpeg", Description = descr, GenreId = "scifi", Price = 6.50D, ISBN = "JHF7UTYS67", Pages = 870, Language = "English" },
            new { BookId = 14, Title = "Go Tell it on the Mountain", BookImageUri = "images/books/novel/bk6.webp", Description = descr, GenreId = "novel", Price = 10.25, ISBN = "JHK89G7856", Pages = 400, Language = "French" },
            new { BookId = 15, Title = "The Revolutionary: Samuel Adams", BookImageUri = "images/books/history/bk4.jpg", Description = descr, GenreId = "history", Price = 15.50, ISBN = "BGFDRT678432", Pages = 600, Language = "French" },
            new { BookId = 16, Title = "Hunger", BookImageUri = "images/books/memoir/bk4.jpeg", Description = descr, GenreId = "memoir", Price = 14.50, ISBN = "GFR3457834RT", Pages = 940, Language = "French" },
            new { BookId = 17, Title = "Murder on the Orient Express", BookImageUri = "images/books/mystery/bk2.jpeg", Description = descr, GenreId = "mystery", Price = 6.75, ISBN = "KLVB672341CV", Pages = 400, Language = "Dutch" },
            new { BookId = 18, Title = "Pride and Prejudice", BookImageUri = "images/books/novel/bk3.jpeg", Description = descr, GenreId = "novel", Price = 8.50, ISBN = "HGRT5674FDR", Pages = 900, Language = "French" },
            new { BookId = 19, Title = "Rebecca", BookImageUri = "images/books/mystery/bk3.jpeg", Description = descr, GenreId = "mystery", Price = 10.99, ISBN = "OPGH89GYT67", Pages = 700, Language = "English" },
            new { BookId = 20, Title = "The Art of War", BookImageUri = "images/books/history/bk5.jpg", Description = descr, GenreId = "history", Price = 5.75, ISBN = "0BF7OOGHS67", Pages = 300, Language = "English" },
            new { BookId = 21, Title = "The Girl with the Dragon Tattoo", BookImageUri = "images/books/mystery/bk4.jpeg", Description = descr, GenreId = "mystery", Price = 8.50, ISBN = "TGBFL89GHS6G", Pages = 800, Language = "English" },
            new { BookId = 22, Title = "The Handmaid's Tale", BookImageUri = "images/books/scifi/bk3.jpeg", Description = descr, GenreId = "scifi", Price = 12.50, ISBN = "GBRF7I9HHS67", Pages = 400, Language = "English" },
            new { BookId = 23, Title = "The Maltese Falcon", BookImageUri = "images/books/mystery/bk5.jpeg", Description = descr, GenreId = "mystery", Price = 10.99, ISBN = "IOIO89GYT77", Pages = 400, Language = "French" },
            new { BookId = 24, Title = "The New Jim Crow", BookImageUri = "images/books/history/bk6.jpeg", Description = descr, GenreId = "history", Price = 13.75, ISBN = "GBF789GHS67", Pages = 400, Language = "English" },
            new { BookId = 25, Title = "The Year of Magical Thinking", BookImageUri = "images/books/memoir/bk5.jpeg", Description = descr, GenreId = "memoir", Price = 13.50, ISBN = "HGBG12365GH", Pages = 700, Language = "English" },
            new { BookId = 26, Title = "Wuthering Heights", BookImageUri = "images/books/novel/bk4.jpeg", Description = descr, GenreId = "novel", Price = 9.00, ISBN = "RTD305TGG12", Pages = 600, Language = "English" },
            new { BookId = 27, Title = "Running With Scissors", BookImageUri = "images/books/memoir/bk6.jpeg", Description = descr, GenreId = "memoir", Price = 11.00, ISBN = "0976GHTR123", Pages = 250, Language = "English" },
            new { BookId = 28, Title = "Pride and Prejudice and Zombies", BookImageUri = "images/books/novel/bk2.jpg", Description = descr, GenreId = "novel", Price = 8.75, ISBN = "653RTF2309", Pages = 550, Language = "English" },
            new { BookId = 29, Title = "Harry Potter and the Sorcerer's Stone", BookImageUri = "images/books/novel/bk1.jpeg", Description = descr, GenreId = "novel", Price = 9.75, ISBN = "2347812@#TX", Pages = 400, Language = "English" }
        );
    }
}
