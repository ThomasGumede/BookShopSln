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

        public async Task<PagedList<Book>> GetAllAsync(bool trackChanges, int pageNumber, int pageSize)
        {
            var books = await FindAll(trackChanges).Select(b => new Book {
                BookId = b.BookId,
                Title = b.Title,
                BookImageUri = b.BookImageUri,
                Price = b.Price
            }).ToListAsync();

            return PagedList<Book>.ToPagedList(books, pageNumber, pageSize);
        }
            

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

            return PagedList<Book>.ToPagedList(books, requestParameters.PageNumber, requestParameters.PageSize);
        }

        public async Task<Book?> GetBookByIdAsync(int bookId, bool trackChanges) =>
            await FindByCondition(book => book.BookId.Equals(bookId), trackChanges)
            .Include(book => book.Authors)
            .Include(book => book.Genre)
            .SingleOrDefaultAsync();

        public void CreateBook(Book book) => Create(book);

        public void DeleteBook(Book book) => Delete(book);
    }
}