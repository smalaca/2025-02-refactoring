namespace _2025_02_refactoring.bookshop;

public class Author
{
    private readonly string _name;
    private readonly string _lastName;

    public Author(string authorName, string authorSurname)
    {
        _name = authorName;
        _lastName = authorSurname;
    }

    internal string getName()
    {
        return _name;
    }
    
    internal string getLastName()
    {
        return _lastName;
    }
}