namespace _2025_02_refactoring.bookshop.api.waitinglist;

public record AddToWaitingListCommand(int readerId, int bookId, DateTime pickUpDate);