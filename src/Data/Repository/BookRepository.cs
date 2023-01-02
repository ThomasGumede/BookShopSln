using Core.Entities;
using Data.Interfaces;
using Data.Request;


using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        { }

        public async Task<IEnumerable<Book>> GetAllAsync(bool trackChanges)
        {
            var books = await FindAll(trackChanges).Select(b => new Book {
                BookId = b.BookId,
                Title = b.Title,
                BookImageUri = b.BookImageUri,
                Price = b.Price
            }).ToListAsync();

            

            return books;
        }

        public async Task<IEnumerable<Book>> GetRandomAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .Select(book => new Book{ 
                BookId = book.BookId, 
                BookImageUri = book.BookImageUri,
                Title = book.Title,
                Description = book.Description,
                Price = book.Price
            })
            .OrderBy(b => EF.Functions.Random())
            .Take(5).ToListAsync();


        public async Task<PagedList<Book>> GetAllAsync(RequestParameters requestParameters, bool trackChanges)
        {
            var books = await FindAll(trackChanges)
                        .FilterBook(requestParameters.FilterTerms)
                        .Search(requestParameters.searchTerm)
                        .Select(b => new Book
                        {
                            BookId = b.BookId,
                            Title = b.Title,
                            BookImageUri = b.BookImageUri,
                            Price = b.Price
                        })
                        .Sort(requestParameters.OrderBy)
                        .ToListAsync();

            var data = PagedList<Book>.ToPagedList(books, requestParameters.PageNumber, requestParameters.PageSize);

            return data;
        }

        public async Task<Book?> GetBookByIdAsync(int bookId, bool trackChanges) =>
            await FindByCondition(book => book.BookId.Equals(bookId), trackChanges)
            .Include(book => book.Authors)
            .Include(book => book.Genre)
            .SingleOrDefaultAsync();
    }
}