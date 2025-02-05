using _2025_02_refactoring.bookshop.api.reader;

namespace _2025_02_refactoring.bookshop;

public class BookController
{
    private readonly BookRepository _bookRepository;
    private readonly ReaderRepository _readerRepository;
    private readonly IsbnService _isbnService;
    
    public void addBook(string name,  string AuthorName, string AuthorSurname, string isbn)
    {
        Book book = new BookBuilder(_isbnService)
            .setName(name)
            .setAuthor(AuthorName, AuthorSurname)
            .setIsbn(isbn)
            .build();
        
        _bookRepository.Update(book);
        
    } 
    
    public void borrowBook(int readerId, int bookId)
    {
        Book book = _bookRepository.FindById(bookId);
        Reader reader = _readerRepository.FindById(readerId);

        reader.Borrow(book);
        
        _bookRepository.Update(book);
    }
    
    public void returnBook(int readerId, int bookId)
    {
        Book book = _bookRepository.FindById(bookId);
        Reader reader = _readerRepository.FindById(readerId);
        
        reader.Return(book);
        
        _bookRepository.Update(book);
    }

    public BookDto findBookById(int bookId)
    {
        Book book = _bookRepository.FindById(bookId);

        return book.asDto();
    }

    public List<BookDto> findAllBook()
    {
        List<Book> books = _bookRepository.findAll();
        
        return books.Select(book => book.asDto()).ToList();
    }
}