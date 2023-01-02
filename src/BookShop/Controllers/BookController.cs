using Data.Request;
using Microsoft.AspNetCore.Mvc;
using BookShop.Models;
using Service.Interfaces;
using Data.Interfaces;
using Microsoft.AspNetCore.WebUtilities;


namespace BookShop.Controllers
{

    public class BookController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IServiceManager _service;

        public BookController(ILoggerManager logger, IServiceManager service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index([FromQuery] RequestParameters requestParameters)
        {
            var books = await _service.bookService.GetAllBooksAsync(requestParameters, false);
            var genres = await _service.genreService.AllGenresAsync(false);

            var BookViewModel = new BookViewModel
            {
                Metadata = books.metaData,
                Books = books.books,
                Genres = genres
            };

            return View(BookViewModel);
        }

        [Route("Details/{bookId}")]
        public async Task<IActionResult> Details(int bookId)
        {
            var book = await _service.bookService.GetBookDetailsAsync(bookId, false);

            if (book is null)
                return NotFound();

            var request = new RequestParameters { FilterTerms = book.GenreId };
            var similarbooks = await _service.bookService.GetAllBooksAsync(request, false);



            var BookDetailViewModel = new BookDetailViewModel
            {
                Book = book,
                SimilarBooks = similarbooks.books.Take(6)
            };

            return View(BookDetailViewModel);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}