namespace _2025_02_refactoring.examples.dry.good;

public class ProductPurchase
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string CustomerEmail { get; set; }

    public void PurchaseProduct()
    {
        ProcessTransaction(true); 
    }

    public void RefundProduct(int quantityToRefund)
    {
        if (quantityToRefund > Quantity)
        {
            throw new Exception("Cannot refund more than purchased.");
        }

        ProcessTransaction(false, quantityToRefund); 
    }

    private void ProcessTransaction(bool isPurchase, int quantity = 0) // Unified method
    {
        decimal amount = isPurchase ? CalculateTotal() : CalculateRefundAmount(quantity);

        if (isPurchase)
        {
            if (!CheckProductAvailability(ProductId, Quantity))
            {
                throw new Exception("Product not available.");
            }

            if (!ProcessPayment(CustomerEmail, amount))
            {
                throw new Exception("Payment failed.");
            }
            UpdateInventory(ProductId, Quantity);
            SendConfirmationEmail(CustomerEmail, ProductId, Quantity);

        }
        else
        {
            if (!ProcessRefund(CustomerEmail, amount))
            {
                throw new Exception("Refund failed.");
            }
            UpdateInventory(ProductId, -quantity);
            SendRefundConfirmationEmail(CustomerEmail, ProductId, quantity);

        }

        LogTransaction(isPurchase, ProductId, quantity, CustomerEmail, amount); // Unified logging
    }


    private bool CheckProductAvailability(int productId, int quantity) { /* ... */ return true; }
    private bool ProcessPayment(string customerEmail, decimal total) { /* ... */ return true; }
    private bool ProcessRefund(string customerEmail, decimal amount) { /* ... */ return true; }
    private void UpdateInventory(int productId, int quantity) { /* ... */ }
    private void SendConfirmationEmail(string customerEmail, int productId, int quantity) { /* ... */ }
    private void SendRefundConfirmationEmail(string customerEmail, int productId, int quantity) { /* ... */ }
    private decimal CalculateTotal() { /* ... */ return 10; }
    private decimal CalculateRefundAmount(int quantity) { /* ... */ return 5 * quantity; }

    private void LogTransaction(bool isPurchase, int productId, int quantity, string customerEmail, decimal amount)
    {
        string transactionType = isPurchase ? "Purchase" : "Refund";
        Console.WriteLine($"{transactionType} - Product: {productId}, Qty: {quantity}, Email: {customerEmail}, Amount: {amount}");
    }
}