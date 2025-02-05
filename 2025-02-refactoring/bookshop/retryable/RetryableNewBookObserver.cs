using _2025_02_refactoring.bookshop.api.waitinglist;

namespace _2025_02_refactoring.bookshop.retryable;

public class RetryableNewBookObserver : NewBookObserver
{
    private readonly NewBookObserver _observer;

    public RetryableNewBookObserver(NewBookObserver observer)
    {
        _observer = observer;
    }

    public void notify(BookDataModel bookDataModel)
    {
        try
        {
            _observer.notify(bookDataModel);
        } catch (Exception e)
        {
            // save in db bookDataModel with information to retry in 5 minutes from now
        }
    }
}