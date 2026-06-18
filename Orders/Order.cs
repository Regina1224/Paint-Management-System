using System;
using PaintManagementSystem.Models;
namespace PaintManagementSystem.Orders;

public class Order
{
    // filed
    public readonly DateTime CreatedAt;

    // props
    public List<PaintProduct> Products { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }

    // constructor: a group of products
    public Order(List<PaintProduct> products, int quantity)
    {
        Products = products;
        Quantity = quantity;
        CreatedAt = DateTime.Now;
        TotalPrice = GetTotalOrderPrice();
    }

    // methods
    public void DisplayOrder()
    {
        Console.WriteLine($"Order created time: {CreatedAt}");
        foreach (PaintProduct product in Products)
        {
            product.DisplayInfo();
            Console.WriteLine("------------------------");
        }
        Console.WriteLine($"Quantity: {Quantity}");
        Console.WriteLine($"Order total price: {TotalPrice:C}");
    }

    public decimal GetTotalOrderPrice()
    {
        return Products.Sum(p=>p.GetFinalPrice()) * Quantity;
    }

    // find most expensive product
    public PaintProduct GetMostExpensivePaintProduct()
    {
        return Products.OrderByDescending(p=>p.GetFinalPrice()).First();
    }

    // remove product
    public void RemoveProduct(int productId)
    {
        if(productId >=0 && productId< Products.Count)
        {
            Products.RemoveAt(productId);
            TotalPrice = GetTotalOrderPrice();
        }

        Console.WriteLine("Invaliad product id");
    }

    public List<PaintProduct> GetProductsInPriceRange(decimal minPrice, decimal maxPrice)
    {
        return Products.Where(p=>p.Price > minPrice && p.Price < maxPrice).ToList();
    }

    public Dictionary<PaintType, decimal> GetTotalPriceByType()
    {
        return Products.GroupBy(p=>p.Type).ToDictionary(
            // key
            g=>g.Key,
            // value
            g=>g.Sum(p=>p.GetFinalPrice())
        );
    }




}
