using System;
using PaintManagementSystem.Models;
namespace PaintManagementSystem.Orders;

public class Order
{
    public readonly DateTime CreatedAt;

    public PaintProduct Product { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }

    public Order(PaintProduct paintProduct, int quantity)
    {
        Product = paintProduct;
        Quantity = quantity;
        TotalPrice = GetTotalPrice();
        CreatedAt = DateTime.Now;
    }

    public void DisplayOrder()
    {
        Console.WriteLine($"Order created time: {CreatedAt}");
        Product.DisplayInfo();
        Console.WriteLine($"Quantity: {Quantity}");
        Console.WriteLine($"Order total price: {TotalPrice:C}");
    }

    public decimal GetTotalPrice()
    {
        return Product.GetFinalPrice() * Quantity;
    }

}
