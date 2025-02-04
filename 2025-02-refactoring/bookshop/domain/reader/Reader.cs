namespace _2025_02_refactoring.bookshop.api.reader;

public class Reader
{
    private const int BORROWED_BOOKS_DEFAULT_MAXIMUM = 2;

    private readonly DateTime _membershipDate;
    private readonly List<BorrowedBook> borrowedBooks;
    private readonly List<int> punishmentIds;

    public void Borrow(Book book)
    {
        if (CanBorrowBook())
        {
            BorrowedBook borrowedBook = book.Borrow(DateTime.Now);
            borrowedBooks.Add(borrowedBook);
        }
    }

    private bool CanBorrowBook()
    {
        return getAllowedBooksToBorrow() > 0;
    }

    public int getAllowedBooksToBorrow()
    {
        DateTime now = DateTime.Now;
        int allowedBooks = BORROWED_BOOKS_DEFAULT_MAXIMUM +
                           YearsOfMembership(now) -
                           AmountOfBorrowedBooks() - 
                           AmountOfPunishments(now);

        return allowedBooks > 0 ? allowedBooks : 0;
    }

    private int AmountOfPunishments(DateTime now)
    {
        return punishmentIds.Count + OngoingDelays(now);
    }

    private int OngoingDelays(DateTime now)
    {
        return borrowedBooks.Select(book => book.isDelayed(now)).Count();
    }

    private int AmountOfBorrowedBooks()
    {
        return borrowedBooks.Count;
    }

    private int YearsOfMembership(DateTime now)
    {
        return _membershipDate.Year - now.Year;
    }
}