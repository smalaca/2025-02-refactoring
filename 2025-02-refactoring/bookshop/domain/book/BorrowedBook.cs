﻿namespace _2025_02_refactoring.bookshop.api.reader;

public class BorrowedBook(int bookId, DateTime borrowedAt, int maxBorrowingDays)
{
    private readonly int _bookId = bookId;
    private readonly DateTime _borrowedAt= borrowedAt;
    private readonly int _maxBorrowingDays = maxBorrowingDays;

    public bool IsDelayed(DateTime now)
    {
        return _borrowedAt.Subtract(now).Days >= _maxBorrowingDays;
    }

    public bool Represents(Book book)
    {
        return book.HasId(_bookId);
    }
}