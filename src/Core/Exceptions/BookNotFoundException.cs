

namespace Core.Exceptions;
public class BookNotFoundException : NotFoundException
{
    public BookNotFoundException(int id) : base($"Book with id: {id} could not be found")
    {
    }
}
