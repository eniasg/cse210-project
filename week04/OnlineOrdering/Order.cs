using System;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product) => _products.Add(product);
    
    public decimal CalculateTotalCost()
    {
        decimal total = _products.Sum(p => p.CalculateTotalCost());
        return total + (_customer.IsInUSA() ? 5 : 35);
    }
    
    public string GetPackingLabel()
    {
        return string.Join("\n", _products.Select(p => $"{p.GetName()} (ID: {p.GetProductId()})"));
    }
    
    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}