namespace _2025_02_refactoring.examples.yagni.good;

public class ProductPurchase
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string CustomerEmail { get; set; }

    public void PurchaseProduct()
    {
        // ... purchase logic ...
    }

    // ... other essential methods ...
}

// If and when bulk discounts become necessary:
public class ProductPurchaseWithBulkDiscount : ProductPurchase
{
    public decimal BulkDiscountPercentage { get; set; }

    // ... bulk discount logic ...
}

// If and when detailed sales reports are required:
public class SalesReportGenerator
{
    public void GenerateDetailedSalesReport(List<ProductPurchase> purchases)
    {
        // ... detailed report generation logic ...
    }
}

// If and when CRM integration is needed:
public class CRMCustomerIntegration
{
    public void UpdateCRM(ProductPurchase purchase)
    {
        // ... CRM integration logic ...
    }
}
