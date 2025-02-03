namespace _2025_02_refactoring.examples.yagni.bad;

public class ProductPurchase
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string CustomerEmail { get; set; }

    // Future-proofing for potential bulk discounts (not currently needed)
    public decimal BulkDiscountPercentage { get; set; } // Unused

    // Support for future integration with a complex CRM system (not needed yet)
    public string CRMCustomerId { get; set; } // Unused

    // Method for generating detailed sales reports (not currently required)
    public void GenerateDetailedSalesReport()
    {
        // ... complex report generation logic (not implemented yet) ...
        throw new NotImplementedException("Detailed sales reports not yet implemented.");
    }

    public void PurchaseProduct()
    {
        // ... purchase logic ...
    }

    // ... other methods ...
}
