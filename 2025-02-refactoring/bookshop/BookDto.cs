namespace _2025_02_refactoring.bookshop;

public class BookDto
{
    public readonly int _bookId;
    public readonly string _name;
    public readonly Author _author;
    public readonly string _isbn;
    public readonly int _publishYear;
    public readonly string _authorName;
    public readonly string _authorLastName;
    public readonly string _status;

    internal BookDto(
        int bookId, string name, Author author, string isbn, 
        int publishYear, string authorName, string authorLastName, 
        string status)
    {
        _bookId = bookId;
        _name = name;
        _author = author;
        _isbn = isbn;
        _publishYear = publishYear;
        _authorName = authorName;
        _authorLastName = authorLastName;
        _status = status;
    }
}