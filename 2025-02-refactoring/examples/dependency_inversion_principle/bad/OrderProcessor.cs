namespace _2025_02_refactoring.examples.dependency_inversion_principle.bad;

// High-level module (OrderProcessor) depends directly on low-level module (PaymentProcessor)
public class OrderProcessor
{
    private PaymentProcessor _paymentProcessor; 

    public OrderProcessor()
    {
        _paymentProcessor = new PaymentProcessor(); // Tight coupling
    }

    public void ProcessOrder(Order order)
    {
        // ... order processing logic ...
        _paymentProcessor.ProcessPayment(order.TotalAmount);
        // ... more order processing ...
    }
}

public class PaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        // ... payment processing logic ...
        Console.WriteLine($"Payment of {amount} processed.");
    }
}

public class Order
{
    public decimal TotalAmount { get; set; }
    // ... other order details ...
}