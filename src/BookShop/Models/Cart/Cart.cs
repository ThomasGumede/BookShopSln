using Data.DTOs;
using Service.Interfaces;
using BookShop.Extensions;
using System.Text.Json.Serialization;

namespace BookShop.Models;

public class Cart
{
    private const string CartKey = "mycart";
    private const string CountKey = "mycount";
    public List<CartItem> items { get; set; } = null!;

    private ISession session { get; set; }

    public Cart(HttpContext ctx)
    {
        session = ctx.Session;
    }

    public void Load()
    {
        items = session.GetJson<List<CartItem>>(CartKey) ?? new List<CartItem>();
    }

    public CartItem? GetById(int id) =>
        items.FirstOrDefault(b => b.Book.bookId == id);

    public int? Count => session.GetInt32(CountKey) ?? 0;

    public virtual void AddItem(BookDto book, int quantity)
    {
        CartItem? line = GetById(book.bookId);
        if (line == null)
        {
            items.Add(new CartItem
            {
                Book = book,
                Quantity = quantity
            });
        }
        else
        {
            line.Quantity += quantity;
        }
    }

    public virtual void UpdateItem(int id, int quantity)
    {
        var item = GetById(id);
        if (item != null)
        {
            item.Quantity = quantity;
        }
    }

    public virtual void RemoveLine(BookDto book) => items.RemoveAll(l => l.Book.bookId == book.bookId);
    public decimal ComputeTotalValue() => (decimal)items.Sum(e => e.Book.Price * (double)e.Quantity);

    public virtual void Clear() => items.Clear();

    public void Save()
    {
        session.SetJson(CartKey, items);
        session.SetJson(CountKey, items.Count);
    }


}

public class CartItem
{
    public int CartItemID { get; set; }
    public BookDto Book { get; set; } = null!;
    public int Quantity { get; set; }
    [JsonIgnore]
    public double Subtotal => Book.Price * Quantity;
}
