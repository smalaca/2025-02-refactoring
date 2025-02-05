using _2025_02_refactoring.bookshop.api.reader;

namespace _2025_02_refactoring.bookshop.api.waitinglist;

public class WaitingList
{
    private readonly int _readerId;
    private readonly Dictionary<int, DateTime> _books;

    public WaitingList(int readerId)
    {
        _readerId = readerId;
    }

    public void add(Reader reader, int bookId, DateTime pickUpDate)
    {
        if (_books.Count < 10)
        {
            throw new ArgumentException("Waiting list is full");
        }
        
        if (pickUpDate < DateTime.Now)
        {
            throw new ArgumentException("Pick up date must be in the future");
        }
        
        if (reader.hasAnyPunishmentInLastYear())
        {
            throw new ArgumentException("Reader has punishment in last year");
        }
        
        _books.Add(bookId, pickUpDate);
    }
}