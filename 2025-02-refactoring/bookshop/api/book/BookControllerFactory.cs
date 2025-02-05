using _2025_02_refactoring.bookshop.api.inventory;
using _2025_02_refactoring.bookshop.api.waitinglist;
using _2025_02_refactoring.bookshop.retryable;

namespace _2025_02_refactoring.bookshop;

public class BookControllerFactory
{
    public BookController create()
    {
        var bookController = new BookController();

        bookController.register(new RetryableNewBookObserver(new NewBookInventoryObserver()));
        bookController.register(new RetryableNewBookObserver(new NewBookWaitingListObserver()));
        
        return bookController;
    }
}