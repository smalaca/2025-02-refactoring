﻿using _2025_02_refactoring.bookshop.api.reader;

namespace _2025_02_refactoring.bookshop;

public class Book
{
    private readonly int _bookId;
    private readonly string _name;
    private readonly Author _author;
    private readonly string _isbn;
    private readonly int _publishYear;
    private readonly int _maxBorrowingDays;
    private bool isBorrowed;

    internal Book(string name, Author author, string isbn)
    {
        _name = name;
        _author = author;
        _isbn = isbn;
    }

    internal BorrowedBook Borrow(DateTime borrowedAt)
    {
        if (isBorrowed)
        {
            throw new BookAlreadyBorrowedException(_bookId);
        }
        
        isBorrowed = true;
        
        return new BorrowedBook(_bookId, borrowedAt, _maxBorrowingDays);
    }

    internal void Return()
    {
        isBorrowed = false;
    }

    internal BookDto asDto()
    {
        var status = isBorrowed ? "borrowed" : "available";
        
        return new BookDto(
            _bookId, _name, _author, _isbn, _publishYear, 
            _author.getName(), _author.getLastName(), status);
    }

    public bool HasId(int bookId)
    {
        return _bookId == bookId;
    }

    public BookDataModel asDataModel()
    {
        return new BookDataModel(
            _bookId, _name, _isbn, _author.getName(), _author.getLastName(), 
            _publishYear, _maxBorrowingDays);
    }
}