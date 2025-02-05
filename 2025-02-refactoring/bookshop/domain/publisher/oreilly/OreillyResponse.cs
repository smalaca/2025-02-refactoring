namespace _2025_02_refactoring.bookshop.domain.publisher.oxford;

public record OreillyResponse(
    bool isSuccessful, string error, int maxBorrowingDays)
{
}