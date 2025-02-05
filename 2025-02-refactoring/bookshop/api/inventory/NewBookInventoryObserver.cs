namespace _2025_02_refactoring.bookshop.api.inventory;

public class NewBookInventoryObserver : NewBookObserver
{
    public void notify(BookDataModel bookDataModel)
    {
        // inform warehouse about new book in inventory
    }
}