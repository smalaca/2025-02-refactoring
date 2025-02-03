namespace _2025_02_refactoring.examples.composition_over_ineritance.good;

public class Discount
{
    public decimal Percentage { get; set; }

    public decimal ApplyDiscount(decimal price)
    {
        return price * (1 - Percentage / 100);
    }

    public string GetDiscountDetails()
    {
        return $"Discount: {Percentage}%";
    }
}

public class FreeShipping
{
    public string GetFreeShippingDetails()
    {
        return "Free Shipping";
    }
}


public class Product
{
    private Discount _discount;
    private FreeShipping _freeShipping;
    private string _name;
    private decimal _price;

    public Product(string name, decimal price)
    {
        _name = name;
        _price = price;
    }

    public void AddDiscount(Discount discount)
    {
        _discount = discount;
    }

    public void AddFreeShipping(FreeShipping freeShipping)
    {
        _freeShipping = freeShipping;
    }

    public string GetProductDetails()
    {
        string details = $"Name: {_name}, Price: {_price}";

        if (_discount != null)
        {
            details = $"{details}, {_discount.GetDiscountDetails()}";
        }

        if (_freeShipping != null)
        {
            details = $"{details}, {_freeShipping.GetFreeShippingDetails()}";
        }

        return details;
    }

    public decimal GetPrice()
    {
        if (_discount != null)
        {
            return _discount.ApplyDiscount(_price);
        }
        
        return _price;
    }
}
