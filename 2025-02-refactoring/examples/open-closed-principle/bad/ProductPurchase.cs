namespace _2025_02_refactoring.examples.open_closed_principle.bad;

public class ProductPurchase
{
    public string ProductType { get; set; } // "Electronics", "Clothing", "Books", etc.
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public decimal CalculateTotal()
    {
        decimal total = Price * Quantity;

        if (ProductType == "Electronics")
        {
            total *= 1.05m; // 5% tax
        }
        else if (ProductType == "Clothing")
        {
            total *= 1.02m; // 2% tax
        }
        else if (ProductType == "Books")
        {
            // No tax
        }
        // ... more product types and tax calculations ...

        return total;
    }
}
