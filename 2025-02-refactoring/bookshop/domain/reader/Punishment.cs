namespace _2025_02_refactoring.bookshop.api.reader;

internal class Punishment
{
    private readonly int _punishmentId;
    internal readonly int _creationDate;

    public bool wasGivenBefore(DateTime dateTime)
    {
        return _creationDate.CompareTo(dateTime) < 0;
    }
}