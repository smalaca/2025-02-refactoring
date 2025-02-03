namespace _2025_02_refactoring.examples.liskov_substitution_principle.good;

public class Product 
{
    private string Name { get; set; }
    protected decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public string GetProductDescription() 
    {
        return $"Name: {Name}, Price: {GetPrice()}";
    }

    public virtual decimal GetPrice() 
    {
        return Price;
    }
}

public class DiscountedProduct : Product
{
    private decimal DiscountPercentage { get; set; }

    public DiscountedProduct(string name, decimal price, decimal discountPercentage) : base(name, price)
    {
        DiscountPercentage = discountPercentage;
    }


    public override decimal GetPrice() 
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
            Console.WriteLine(item.GetProductDescription());
        }
    }
}

