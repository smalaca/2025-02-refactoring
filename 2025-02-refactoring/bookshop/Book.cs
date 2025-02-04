namespace _2025_02_refactoring.bookshop;

public class Book
{
    private readonly int _bookId;
    private readonly string _name;
    private readonly Author _author;
    private readonly string _isbn;
    private readonly int _publishYear;
    private bool isBorrowed;

    internal void Borrow()
    {
        if (isBorrowed)
        {
            throw new BookAlreadyBorrowedException(_bookId);
        }
        
        isBorrowed = true;
    }

    internal void Return()
    {
        isBorrowed = false;
    }

    internal BookDto asDto()
    {
        var status = isBorrowed ? "borrowed" : "available";
        
        return new BookDto(
            _bookId, _name, _author, _isbn, _publishYear, 
            _author.getName(), _author.getLastName(), status);
    }
}