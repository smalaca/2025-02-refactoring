namespace _2025_02_refactoring.bookshop;

public record BookDataModel(
    int bookId, string name, string isbn, string getName, string getLastName, 
    int publishYear, int maxBorrowingDays) 
{
    
}