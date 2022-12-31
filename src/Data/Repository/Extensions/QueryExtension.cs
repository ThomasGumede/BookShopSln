using System.Linq.Dynamic.Core;
using Core.Entities;

namespace Data.Repository;

public static class QueryExtension
{
    public static IQueryable<Book> FilterBook(this IQueryable<Book> source, List<string>? genres)
    {
        if(genres == null)
            return source;
        
        if(genres.Contains("all"))
            return source;

        return source.Where(c => genres.Contains(c.GenreId!));
    }

    public static IQueryable<Book> Search(this IQueryable<Book> source, string? searchTerm)
    {
        if(string.IsNullOrEmpty(searchTerm))
        {
            return source;
        }

        var lowerSearch = searchTerm.Trim().ToLower();

        return source.Where(book => (book.Title.ToLower().Contains(lowerSearch) || book.ISBN.ToLower().Contains(lowerSearch)));
    }

    public static IQueryable<Book> Sort(this IQueryable<Book> source, string? orderByQueryString)
    {
        if(string.IsNullOrEmpty(orderByQueryString))
            return source.OrderBy(book => book.Title);

        var sortTerm = QueryOrderByBuilder.CreateOrderQuery<Book>(orderByQueryString);
        if(string.IsNullOrWhiteSpace(sortTerm))
            return source.OrderBy(b => b.Title);

        return source.OrderBy(sortTerm);
    }
}