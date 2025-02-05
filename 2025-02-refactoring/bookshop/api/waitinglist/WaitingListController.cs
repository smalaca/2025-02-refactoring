using _2025_02_refactoring.bookshop.api.reader;

namespace _2025_02_refactoring.bookshop.api.waitinglist;

public class WaitingListController
{
    private readonly WaitingListRepository _waitingListRepository;
    private readonly ReaderRepository _readerRepository;
    
    public void AddToWaitingList(AddToWaitingListCommand command)
    {
        var reader = _readerRepository.FindById(command.readerId);
        var waitingList = WaitingListFor(command.readerId);

        waitingList.add(reader, command.bookId, command.pickUpDate);
        
        _waitingListRepository.Save(waitingList);
    }

    private WaitingList WaitingListFor(int readerId)
    {
        WaitingList? waitingList = _waitingListRepository.FindById(readerId);

        if (waitingList == null)
        {
            waitingList = new WaitingList(readerId);
        }

        return waitingList;
    }
}