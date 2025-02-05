namespace _2025_02_refactoring.bookshop.api.waitinglist;

public class Notification
{
    private readonly string _mailAddress;
    private readonly string _title;
    private readonly string _content;

    public Notification(string mailAddress, string title, string content)
    {
        _mailAddress = mailAddress;
        _title = title;
        _content = content;
    }
}