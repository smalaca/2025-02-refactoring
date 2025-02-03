namespace _2025_02_refactoring.examples.dependency_inversion_principle.good;

public class OrderProcessor
{
    private IPaymentProcessor _paymentProcessor; 

    public OrderProcessor(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
    }

    public void ProcessOrder(Order order)
    {
        // ... order processing logic ...
        _paymentProcessor.ProcessPayment(order.TotalAmount);
        // ... more order processing ...
    }
}

public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}

public class PaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        // ... payment processing logic ...
    }
}

public class PaymentGateway : IPaymentProcessor
{
    public void ProcessPayment(decimal amount)
    {
        // ... payment processing logic for another gateway ...
    }
}

public class Order
{
    public decimal TotalAmount { get; set; }
    // ... other order details ...
}