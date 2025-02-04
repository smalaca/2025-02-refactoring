namespace _2025_02_refactoring.bookshop;

internal class BookAlreadyBorrowedException : Exception
{
    private readonly int _bookId;

    internal BookAlreadyBorrowedException(int bookId)
    {
        _bookId = bookId;
    }
}