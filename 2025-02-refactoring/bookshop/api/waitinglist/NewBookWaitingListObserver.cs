using _2025_02_refactoring.bookshop.api.reader;

namespace _2025_02_refactoring.bookshop.api.waitinglist;

public class NewBookWaitingListObserver : NewBookObserver
{
    private readonly NotificationService _notificationService;
    private readonly WaitingListRepository _waitingListRepository;
    private readonly ReaderRepository _readerRepository;
    
    public void notify(BookDataModel bookDataModel)
    {
        List<WaitingList> waitingLists = _waitingListRepository.FindAllByBookId(bookDataModel.bookId);
        List<int> readerIds = waitingLists.Select(waitingList => waitingList.getReaderId()).ToList();
        List<Reader> readers = _readerRepository.findAllByIds(readerIds);
        List<String> mail;
        List<Notification> notifications;

        notifications.ForEach(notfication => _notificationService.send(notfication));
    }
}