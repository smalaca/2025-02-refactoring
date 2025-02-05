namespace _2025_02_refactoring.bookshop.api.reader;

public class Reader
{
    private const int BORROWED_BOOKS_DEFAULT_MAXIMUM = 2;

    private readonly int _readerId;
    private readonly DateTime _membershipDate;
    private readonly List<BorrowedBook> _borrowedBooks;
    private readonly List<Punishment> _punishments;

    public void Borrow(Book book)
    {
        if (CanBorrowBook())
        {
            BorrowedBook borrowedBook = book.Borrow(DateTime.Now);
            _borrowedBooks.Add(borrowedBook);
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
        return _punishments.Count + OngoingDelays(now);
    }

    private int OngoingDelays(DateTime now)
    {
        return _borrowedBooks.Select(book => book.IsDelayed(now)).Count();
    }

    private int AmountOfBorrowedBooks()
    {
        return _borrowedBooks.Count;
    }

    private int YearsOfMembership(DateTime now)
    {
        return _membershipDate.Year - now.Year;
    }

    public void Return(Book book)
    {
        book.Return();
        
        BorrowedBook? found = _borrowedBooks.Find(borrowedBook => borrowedBook.Represents(book));
        
        if (found != null)
        {
            _borrowedBooks.Remove(found);
        }
    }

    public int getId()
    {
        return _readerId;
    }

    public bool hasAnyPunishmentInLastYear()
    {
        return PunishmentInLastYear() > 0;
    }

    private int PunishmentInLastYear()
    {
        return ExistingPunishmentsInLastYear() + OngoingDelays(DateTime.Now);
    }

    private int ExistingPunishmentsInLastYear()
    {
        var lastYear = DateTime.Now.AddYears(-1);
        
        return _punishments
            .Select(punishment => punishment.wasGivenBefore(lastYear))
            .Count();
    }
}