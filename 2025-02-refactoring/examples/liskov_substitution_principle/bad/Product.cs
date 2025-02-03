namespace _2025_02_refactoring.examples.liskov_substitution_principle.bad;

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public virtual string GetProductDetails()
    {
        return $"Name: {Name}, Price: {Price}";
    }
}

public class DiscountedProduct : Product
{
    public decimal DiscountPercentage { get; set; }

    public override string GetProductDetails()
    {
        return $"{base.GetProductDetails()}, Discount: {DiscountPercentage}%"; 
    }

    public decimal GetDiscountedPrice()
    {
        return Price * (1 - DiscountPercentage / 100);
    }
}

public class ShoppingCart
{
    public List<Product> Items { get; set; } = new List<Product>();

    public void PrintProductDetails()
    {
        foreach (var item in Items)
        {
            // Wrong format
            // Wrong price
            Console.WriteLine(item.GetProductDetails()); 
        }
    }
}

