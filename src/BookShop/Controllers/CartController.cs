using Microsoft.AspNetCore.Mvc;
using BookShop.Models;
using Service.Interfaces;
using Data.Interfaces;


namespace BookShop.Controllers;


public class CartController : Controller
{
    private readonly IServiceManager _service;
    
    private Cart _cart;

    private Cart GetCart(IHttpContextAccessor httpctx)
    {
        var cart = new Cart(httpctx.HttpContext!);
        cart.Load();
        return cart;
    }

    public CartController(IServiceManager service, IHttpContextAccessor httpctx)
    {

        _service = service;
        _cart = GetCart(httpctx);
    }

    public IActionResult Index()
    {
        
        var vm = new CartVM
        {
            List = _cart.items,
            Subtotal = _cart.ComputeTotalValue()
        };
        return View(vm);
    }

    
    [Route("Add/{id}/{quantity}")]
    public async Task<IActionResult> Add(int id, int quantity)
    {
        var books = await _service.bookService.GetAllBooksAsync(false);
        var bookdto = books.FirstOrDefault(b => b.bookId == id);
        if (bookdto is null)
        {
            return NotFound();
        }
        _cart.AddItem(bookdto, quantity);
        _cart.Save();
        return RedirectToAction(nameof(Index));

    }

    [HttpPost]
    public async Task<JsonResult> Remove(int id)
    {
        var books = await _service.bookService.GetAllBooksAsync(false);
        var bookdto = books.FirstOrDefault(b => b.bookId == id);
        if (bookdto is null)
        {
            return Json(new { success = false, model = "Book not found" });
        }
        _cart.RemoveLine(bookdto);

        return Json(new { success = true, model = "Book remove from cart" });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
