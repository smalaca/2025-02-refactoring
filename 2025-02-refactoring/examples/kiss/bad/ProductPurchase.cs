namespace _2025_02_refactoring.examples.kiss.bad;

public class ProductPurchase
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string CustomerEmail { get; set; }

    public void PurchaseProduct()
    {
        try
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

            string logMessage = $"Purchase successful for ProductId: {ProductId}, Quantity: {Quantity}, Customer: {CustomerEmail}, Total: {CalculateTotal()}";
            LogPurchase(logMessage, "INFO", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); 
        }
        catch (Exception ex)
        {
            LogError(ex, "ERROR", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            throw; // Re-throw the exception after logging
        }
    }

    private void LogPurchase(string message, string level, string timestamp)
    {
        // ... complex logging logic, maybe writing to multiple files, databases, etc. ...
        Console.WriteLine($"{timestamp} - {level}: {message}"); // Just a simple example
    }

    private void LogError(Exception ex, string level, string timestamp)
    {
        // ... complex error logging, including stack traces, etc. ...
        Console.WriteLine($"{timestamp} - {level}: {ex.Message}"); // Just a simple example
    }
    
    private bool CheckProductAvailability(int productId, int quantity) { /* ... */ return true; }
    private bool ProcessPayment(string customerEmail, decimal total) { /* ... */ return true; }
    private void UpdateInventory(int productId, int quantity) { /* ... */ }
    private void SendConfirmationEmail(string customerEmail, int productId, int quantity) { /* ... */ }
    private decimal CalculateTotal() { /* ... */ return 10; }
}