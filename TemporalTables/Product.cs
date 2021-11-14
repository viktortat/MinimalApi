
using Microsoft.EntityFrameworkCore;

public class Product
{
    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public Guid Id { get; private set; }
    public string Name { get; init; }
    [Precision(18,2)]
    public decimal Price { get; set; }
}