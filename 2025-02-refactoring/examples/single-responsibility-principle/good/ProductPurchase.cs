namespace _2025_02_refactoring.examples.single_responsibility_principle.good;

public class ProductPurchase
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string CustomerEmail { get; set; }

    private readonly InventoryService _inventoryService;
    private readonly PaymentService _paymentService;
    private readonly ConfirmationService _confirmationService; // For email

    public ProductPurchase(InventoryService inventoryService, PaymentService paymentService, ConfirmationService confirmationService)
    {
        _inventoryService = inventoryService;
        _paymentService = paymentService;
        _confirmationService = confirmationService;
    }


    public void CreateOrder()
    {
        if (!_inventoryService.CheckProductAvailability(ProductId, Quantity))
        {
            throw new Exception("Product not available.");
        }

        _paymentService.ProcessPayment(CustomerEmail, CalculateTotal());
        _inventoryService.UpdateInventory(ProductId, Quantity);
        _confirmationService.SendConfirmationEmail(CustomerEmail, ProductId, Quantity);
    }

    private decimal CalculateTotal() { /* ... */ return 10; }
}

public class InventoryService
{
    public bool CheckProductAvailability(int productId, int quantity) { /* ... */ return true; }
    public void UpdateInventory(int productId, int quantity) { /* ... */ }
}

public class PaymentService
{
    public void ProcessPayment(string customerEmail, decimal total) { /* ... */ }
}

public class ConfirmationService
{
    public void SendConfirmationEmail(string customerEmail, int productId, int quantity) { /* ... */ }
}

