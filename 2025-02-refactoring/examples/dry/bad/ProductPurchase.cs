namespace _2025_02_refactoring.examples.dry.bad;

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
        LogPurchase(ProductId, Quantity, CustomerEmail, CalculateTotal()); // Logging

    }

    public void RefundProduct(int quantityToRefund)
    {
        if (quantityToRefund > Quantity)
        {
            throw new Exception("Cannot refund more than purchased.");
        }

        if (!ProcessRefund(CustomerEmail, CalculateRefundAmount(quantityToRefund)))
        {
            throw new Exception("Refund failed.");
        }

        UpdateInventory(ProductId, -quantityToRefund); // Note the negative quantity for refund
        SendRefundConfirmationEmail(CustomerEmail, ProductId, quantityToRefund);
        LogRefund(ProductId, quantityToRefund, CustomerEmail, CalculateRefundAmount(quantityToRefund)); // Logging - very similar to Purchase logging.
    }

    private bool CheckProductAvailability(int productId, int quantity) { /* ... */ return true; }
    private bool ProcessPayment(string customerEmail, decimal total) { /* ... */ return true; }
    private bool ProcessRefund(string customerEmail, decimal amount) { /* ... */ return true; }
    private void UpdateInventory(int productId, int quantity) { /* ... */ }
    private void SendConfirmationEmail(string customerEmail, int productId, int quantity) { /* ... */ }
    private void SendRefundConfirmationEmail(string customerEmail, int productId, int quantity) { /* ... */ }
    private decimal CalculateTotal() { /* ... */ return 10; }
    private decimal CalculateRefundAmount(int quantity) { /* ... */ return 5 * quantity; }

    // Duplicate logging logic!
    private void LogPurchase(int productId, int quantity, string customerEmail, decimal total)
    {
        Console.WriteLine($"Purchase - Product: {productId}, Qty: {quantity}, Email: {customerEmail}, Total: {total}");
    }

    private void LogRefund(int productId, int quantity, string customerEmail, decimal amount)
    {
        Console.WriteLine($"Refund - Product: {productId}, Qty: {quantity}, Email: {customerEmail}, Amount: {amount}");
    }
}
