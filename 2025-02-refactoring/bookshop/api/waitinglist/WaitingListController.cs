using _2025_02_refactoring.bookshop.api.reader;

namespace _2025_02_refactoring.bookshop.api.waitinglist;

public class WaitingListController
{
    private readonly WaitingListRepository _waitingListRepository;
    private readonly ReaderRepository _readerRepository;
    
    public void AddToWaitingList(AddToWaitingListCommand command)
    {
        var waitingList = WaitingListFor(command.bookId);
        var reader = _readerRepository.FindById(command.readerId);

        waitingList.add(reader, command.pickUpDate);
        
        _waitingListRepository.Save(waitingList);
    }

    private WaitingList WaitingListFor(int bookId)
    {
        WaitingList? waitingList = _waitingListRepository.FindById(bookId);

        if (waitingList == null)
        {
            waitingList = new WaitingList(bookId);
        }

        return waitingList;
    }
}