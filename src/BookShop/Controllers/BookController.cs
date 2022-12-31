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
        // [Route("filter/{filterterms?}/orderby/{orderby?}")]
        public async Task<IActionResult> Index([FromRoute]RequestParameters requestParameters)
        {
            var books = await _service.bookService.GetAllBooksAsync(requestParameters, false);
            var genres = await _service.genreService.AllGenresAsync(false);
            Console.WriteLine("books.metaData.CurrentPage");
            _logger.LogInfo($"CURRENT PAGE {books.metaData.CurrentPage}");
            Console.WriteLine(books.metaData.CurrentPage);
            var BookViewModel = new BookViewModel
            {
                MetaData = books.metaData,
                Books = books.bookDtos,
                Genres = genres
            };

            return View(BookViewModel);
        }
        [Route("Details/{bookId}")]
        public async Task<IActionResult> Details(int bookId)
        {
            var book = await _service.bookService.GetBookDetailsAsync(bookId, false);

            if(book is null)
                return NotFound();

            var BookDetailViewModel = new BookDetailViewModel
            {
                Book = book
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