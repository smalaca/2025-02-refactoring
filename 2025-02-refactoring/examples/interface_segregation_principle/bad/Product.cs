namespace _2025_02_refactoring.examples.interface_segregation_principle.bad;

public interface IProductPurchase
{
    void Purchase();
    void Refund();
    void TrackInventory(); // Not relevant for all product types
    void GenerateSalesReport(); // Not relevant for all product types
}

public class PhysicalProduct : IProductPurchase
{
    public void Purchase() { /* ... */ }
    public void Refund() { /* ... */ }
    public void TrackInventory() { /* ... */ }
    public void GenerateSalesReport() { /* ... */ }
}

public class DigitalProduct : IProductPurchase
{
    public void Purchase() { /* ... */ }
    public void Refund() { /* ... */ }
    public void TrackInventory() { /*  Throws NotImplementedException - not applicable */ } // Problem!
    public void GenerateSalesReport() { /* Throws NotImplementedException - not applicable */ } // Problem!
}