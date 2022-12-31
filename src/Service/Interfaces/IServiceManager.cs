using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Interfaces;

public interface IServiceManager
{
    IBookService bookService { get; }
    IAuthorService authorService { get; }
IGenreService genreService { get; }

}
