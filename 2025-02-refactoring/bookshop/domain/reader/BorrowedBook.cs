namespace _2025_02_refactoring.bookshop.api.reader;

internal class BorrowedBook
{
    private readonly int _bookId;
    private readonly DateTime _borrowedAt;
    private readonly int _maxBorrowingDays;

    public bool isDelayed(DateTime now)
    {
        return _borrowedAt.Subtract(now).Days >= _maxBorrowingDays;
    }
}