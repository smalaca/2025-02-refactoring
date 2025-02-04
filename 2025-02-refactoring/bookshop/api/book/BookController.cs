namespace _2025_02_refactoring.bookshop;

public class BookController
{
    private readonly BookRepository _bookRepository;
    
    public void borrowBook(int bookId)
    {
        Book book = _bookRepository.FindById(bookId);
        
        book.Borrow();
        
        _bookRepository.Update(book);
    }
    
    public void returnBook(int bookId)
    {
        Book book = _bookRepository.FindById(bookId);
        
        book.Return();
        
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