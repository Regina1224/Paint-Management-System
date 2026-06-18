
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

// test new methods for products
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


// create an user
User user = new User("Joe");
user.Orders.Add(order);

// create another order
List<PaintProduct> secondOrderProducts = new List<PaintProduct> { products[1] };
Order secondOrder = new Order(secondOrderProducts, 2);
user.Orders.Add(secondOrder);

// create payment history records and add to user
Payment payment1 = new Payment(1, order, PaymentStatus.Success, order.TotalPrice, PaymentMethod.Alipay);
Payment payment2 = new Payment(2, secondOrder, PaymentStatus.Pending, secondOrder.TotalPrice, PaymentMethod.CreditCard);
Payment payment3 = new Payment(3, order, PaymentStatus.Success, 5m, PaymentMethod.BankTransfer);

user.Payments.Add(payment1);
user.Payments.Add(payment2);
user.Payments.Add(payment3);


// test Order methods
Console.WriteLine("===== Most expensive order =====");
user.GetMostExpensiveOrder().DisplayOrder();

Console.WriteLine("===== Latest order =====");
user.GetLatestOrder().DisplayOrder();

// test Payment methods
Console.WriteLine("===== Cheapest payment =====");
user.GetCheapestPayment().DisplayPayment();

Console.WriteLine("===== Latest payment =====");
user.GetLatestPayment().DisplayPayment();

Console.WriteLine("===== Payments above 10 =====");
List<Payment> bigPayments = user.GetPaymentsAboveTen();
foreach (Payment p in bigPayments)
{
    p.DisplayPayment();
    Console.WriteLine("------------------------");
}


