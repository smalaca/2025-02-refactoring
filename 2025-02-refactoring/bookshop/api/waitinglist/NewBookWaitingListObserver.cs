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
        List<String> mailAddresses = readers.Select(reader => reader.getMailAddress()).ToList();
        List<Notification> notifications = mailAddresses .Select(mailAddress => AsNotification(bookDataModel, mailAddress)).ToList();

        notifications.ForEach(notification => _notificationService.send(notification));
    }

    private static Notification AsNotification(BookDataModel bookDataModel, string mailAddress)
    {
        return new Notification(mailAddress, "New book is available", bookDataModel.name);
    }
}