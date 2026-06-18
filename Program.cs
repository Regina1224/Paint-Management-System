
using PaintManagementSystem.Models;
using PaintManagementSystem.Orders;

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
Order order = new Order(products[0], 3);
// display order details
Console.WriteLine("===== Order details =====");
order.DisplayOrder();

