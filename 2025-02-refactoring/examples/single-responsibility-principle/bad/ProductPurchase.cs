namespace _2025_02_refactoring.examples.single_responsibility_principle.bad;

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

        ProcessPayment(CustomerEmail, CalculateTotal());
        UpdateInventory(ProductId, Quantity);
        SendConfirmationEmail(CustomerEmail, ProductId, Quantity);
    }

    private bool CheckProductAvailability(int productId, int quantity) { /* ... */  return true; }
    private void ProcessPayment(string customerEmail, decimal total) { /* ... */ }
    private void UpdateInventory(int productId, int quantity) { /* ... */ }
    private void SendConfirmationEmail(string customerEmail, int productId, int quantity) { /* ... */ }
    private decimal CalculateTotal() { /* ... */ return 10; }
}
