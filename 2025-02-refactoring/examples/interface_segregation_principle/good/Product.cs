namespace _2025_02_refactoring.examples.interface_segregation_principle.good;

public class PhysicalProduct : IPurchasable, IInventoryTrackable, IReportable
{
    public void Purchase() { /* ... */ }
    public void Refund() { /* ... */ }
    public void TrackInventory() { /* ... */ }
    public void GenerateSalesReport() { /* ... */ }
}

public class DigitalProduct : IPurchasable
{
    public void Purchase() { /* ... */ }
    public void Refund() { /* ... */ }
    // No need to implement IInventoryTrackable or IReportable
}

public interface IPurchasable
{
    void Purchase();
    void Refund();
}

public interface IInventoryTrackable
{
    void TrackInventory();
}

public interface IReportable
{
    void GenerateSalesReport();
}