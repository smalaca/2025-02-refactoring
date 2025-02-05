namespace _2025_02_refactoring.bookshop.api.waitinglist;

public class WaitingListController
{
    private readonly WaitingListRepository _waitingListRepository;
    
    public void AddToWaitingList(AddToWaitingListCommand command)
    {
        var waitingList = WaitingListFor(command.bookId);

        waitingList.add(command.readerId, command.pickUpDate);
        
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