
using PaintManagementSystem.Models;
using PaintManagementSystem.Orders;
using System.Collections.Generic;

PaintProduct[] products = new PaintProduct[3];

products[0] = new PaintProduct(
    "White primer",
    PaintType.BaseCoat,
    new PaintSpecification("white", 5),
    50m
);

products[1] = new PaintProduct(
    "Red high gloss paint",
    PaintType.Glossy,
    new PaintSpecification("red", 2),
    80m
);

products[2] = new PaintProduct(
    "Gray matte paint",
    PaintType.Matte,
    new PaintSpecification("gray", 1),
    120m
);


// display all avaliable product
Console.WriteLine("===== All avaliable product =====");
foreach (PaintProduct product in products)
{
    product.DisplayInfo();
    Console.WriteLine("------------------------");
}

// create an order
List<PaintProduct> orderProducts = new List<PaintProduct>{ products[0], products[1], products[2] };
Order order = new Order(orderProducts, 1);

// display order details
Console.WriteLine("===== Order details =====");
order.DisplayOrder();

// test new methods
Console.WriteLine("===== Most expensive product =====");
PaintProduct mostExpensive = order.GetMostExpensivePaintProduct();
mostExpensive.DisplayInfo();

Console.WriteLine("===== Products priced between 60 and 130 =====");
List<PaintProduct> rangeProduct = order.GetProductsInPriceRange(60m, 130m);
foreach (PaintProduct p in rangeProduct)
{
    p.DisplayInfo();
    Console.WriteLine("------------------------");
}


Console.WriteLine("===== Total price by paint type =====");
Dictionary<PaintType, decimal> groupProduct = order.GetTotalPriceByType();
foreach(var entry in groupProduct)
{
    Console.WriteLine($"{entry.Key}: {entry.Value:C}");
}



