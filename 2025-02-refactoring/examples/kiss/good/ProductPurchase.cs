namespace _2025_02_refactoring.examples.kiss.good;

public class ProductPurchase
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string CustomerEmail { get; set; }

    public void PurchaseProduct()
    {
        if (!CheckProductAvailability(ProductId, Quantity))
        {
            throw new Exception("Product not available.");
        }

        if (!ProcessPayment(CustomerEmail, CalculateTotal()))
        {
            throw new Exception("Payment failed.");
        }

        UpdateInventory(ProductId, Quantity);
        SendConfirmationEmail(CustomerEmail, ProductId, Quantity);

        Console.WriteLine($"Purchase successful for ProductId: {ProductId}, Quantity: {Quantity}, Customer: {CustomerEmail}, Total: {CalculateTotal()}");
    }

    private bool CheckProductAvailability(int productId, int quantity) { /* ... */ return true; }
    private bool ProcessPayment(string customerEmail, decimal total) { /* ... */ return true; }
    private void UpdateInventory(int productId, int quantity) { /* ... */ }
    private void SendConfirmationEmail(string customerEmail, int productId, int quantity) { /* ... */ }
    private decimal CalculateTotal() { /* ... */ return 10; }
}
