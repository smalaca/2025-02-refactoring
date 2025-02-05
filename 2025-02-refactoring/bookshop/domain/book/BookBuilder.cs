namespace _2025_02_refactoring.bookshop;

public class BookBuilder
{
    private readonly IsbnService _isbnService;
    private string _name;
    private Author _author;
    private string _isbn;

    public BookBuilder(IsbnService isbnService)
    {
        _isbnService = isbnService;
    }

    public BookBuilder setName(string name)
    {
        this._name = name;
        return this;
        
    }

    public BookBuilder setAuthor(string authorName, string authorSurname)
    {
        this._author = new Author(authorName, authorSurname);
        return this;
    }

    public BookBuilder setIsbn(string isbn)
    {
        this._isbn = isbn;
        return this;
    }

    public Book build()
    {
        if (_isbnService.exists(_isbn))
        {
            
            return new Book(_name, _author, _isbn);
        }

        return null;

    }
}

public interface IsbnService
{
    bool exists(string isbn);
}