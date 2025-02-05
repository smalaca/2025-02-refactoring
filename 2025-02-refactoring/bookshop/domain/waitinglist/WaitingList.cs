namespace _2025_02_refactoring.bookshop.api.waitinglist;

public class WaitingList
{
    private readonly int _bookId;
    private readonly List<Waiting> _waitings;

    public WaitingList(int bookId)
    {
        _bookId = bookId;
    }

    public void add(int readerId, DateTime pickUpDate)
    {
        _waitings.Add(new Waiting(readerId, pickUpDate));
    }
}