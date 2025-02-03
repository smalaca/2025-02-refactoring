namespace _2025_02_refactoring.examples.open_closed_principle.good;

public class Product 
{
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public ITaxCalculator TaxCalculator { get; set; }

    public decimal CalculateTotal()
    {
        return (Price + TaxCalculator.CalculateTax(Price)) * Quantity;
    }
}

public interface ITaxCalculator
{
    decimal CalculateTax(decimal price);
}

public class ElectronicsTaxCalculator : ITaxCalculator
{
    public decimal CalculateTax(decimal price)
    {
        return price * 0.05m;
    }
}

public class ClothingTaxCalculator : ITaxCalculator
{
    public decimal CalculateTax(decimal price)
    {
        return price * 0.02m;
    }
}

public class NoTaxCalculator : ITaxCalculator
{
    public decimal CalculateTax(decimal price)
    {
        return 0;
    }
}
