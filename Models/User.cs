using System;
using PaintManagementSystem.Orders;
namespace PaintManagementSystem.Models;

public class User
{
    public string Name { get; set; }
    public List<Order> Orders { get; set; }
    public List<Payment> Payments { get; set; }

    public User(string name)
    {
        Name = name;
        // Initialized to an empty list
        Orders = new List<Order>();
        Payments = new List<Payment>();
    }

    // Order methods
    public Order GetMostExpensiveOrder()
    {
        return Orders.OrderByDescending(o=>o.TotalPrice).First();
    }

    public Order GetLatestOrder()
    {
        return Orders.OrderByDescending(o=>o.CreatedAt).First();
    }



    // Payment methods
    public Payment GetCheapestPayment()
    {
        return Payments.OrderBy(p=>p.PaymentAmount).First();
    }

    public Payment GetLatestPayment()
    {
        return Payments.OrderByDescending(p=>p.CreatedAt).First();
    }

    public List<Payment> GetPaymentsAboveTen()
    {
        return Payments.Where(p=>p.PaymentAmount>10).ToList();
    }

}
