using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookShop.Models;
using Service.Interfaces;
using Data.Request;

namespace BookShop.Controllers;

public class HomeController : Controller
{
    private readonly IServiceManager _service;

    public HomeController(IServiceManager service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var books = await _service.bookService.GetAllBooksAsync(false);
        var authors = await _service.authorService.AllAuthorsAsync(false);
        var genres = await _service.genreService.AllGenresAsync(false);

        var home = new HomeViewModel
        {
            Books = books.Take(5),
            RandomBooks = await _service.bookService.GetRandomBooksAsync(false),
            Authors = authors.Take(5),
            Genres = genres.Take(5)
        };



        return View(home);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
