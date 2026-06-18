using System;
using PaintManagementSystem.Interfaces;

namespace PaintManagementSystem.Models;

public class PaintProduct : IBuyable
{
    // fields
    public readonly decimal TaxRate;
    public const decimal DefaultDiscount = 0.05m;

    // props
    public string Name { get; set; }
    public PaintType Type { get; set; }
    public PaintSpecification Specification{ get; set; }
    public decimal Price {get; set; }

    // constructor
    public PaintProduct(string name, PaintType type, PaintSpecification specification, decimal price)
    {
        Name = name;
        Type = type;
        Specification = specification;
        Price = price;
        TaxRate = 0.10m;
    }

    // achieve interface method
    public decimal GetFinalPrice()
    {
        decimal discountedPrice = Price * (1 - DefaultDiscount);
        decimal finalPrice = discountedPrice * (1 + TaxRate);
        return finalPrice;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Paint name: {Name}");
        Console.WriteLine($"Paint type: {Type}");
        Specification.DisplaySpecification();
        Console.WriteLine($"Paint origin price: {Price:C}");
        Console.WriteLine($"Price including tax after discount: {GetFinalPrice():C}");

    }

    public decimal GetMaxDiscount(int rate, bool isOverridable)
    {
        decimal customDiscount = rate / 100m;

        if (isOverridable)
        {
            return customDiscount;
        }
        return Math.Max(customDiscount, DefaultDiscount);
    }




}
