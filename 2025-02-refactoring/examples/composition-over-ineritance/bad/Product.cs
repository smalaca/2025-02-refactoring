namespace _2025_02_refactoring.examples.composition_over_ineritance.bad;

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

public class FreeShippingProduct : Product
{
    public override string GetProductDetails()
    {
        return $"{base.GetProductDetails()}, Free Shipping";
    }
}

// ?????
public class DiscountedFreeShippingProduct : DiscountedProduct 
{
    public override string GetProductDetails()
    {
        return $"{base.GetProductDetails()}, Free Shipping"; 
    }
}