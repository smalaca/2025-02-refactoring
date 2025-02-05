using _2025_02_refactoring.bookshop.api.reader;

namespace _2025_02_refactoring.bookshop.api.waitinglist;

public class WaitingList
{
    private readonly int _bookId;
    private readonly List<Waiting> _waitings;

    public WaitingList(int bookId)
    {
        _bookId = bookId;
    }

    public void add(Reader reader, DateTime pickUpDate)
    {
        if (pickUpDate < DateTime.Now)
        {
            throw new ArgumentException("Pick up date must be in the future");
        }
        
        _waitings.Add(new Waiting(reader.getId(), pickUpDate));
    }
}