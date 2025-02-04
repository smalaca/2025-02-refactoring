namespace _2025_02_refactoring.bookshop.api.reader;

public class ReaderController
{
    private readonly ReaderRepository _readerRepository;
    
    public int CountAllowedBooksToBorrow(int readerId)
    {
        Reader reader = _readerRepository.FindById(readerId);

        return reader.getAllowedBooksToBorrow();
    }
}