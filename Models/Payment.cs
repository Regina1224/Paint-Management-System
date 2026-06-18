using System;
using System.Reflection.Metadata;
using PaintManagementSystem.Orders;

namespace PaintManagementSystem.Models;

public class Payment
{
    // props
    public Order Order { get; set; }
    public int PaymentId { get; set; }
    public PaymentStatus Status { get; set; }
    public decimal PaymentAmount { get; set; }
    public PaymentMethod Method { get; set; }
    public readonly DateTime CreatedAt;
  
    // constructor
    public Payment(int paymentId, Order order, PaymentStatus status, decimal paymentAmount, PaymentMethod method)
    {
        Order = order;
        PaymentId = paymentId;
        Status = status;
        PaymentAmount = paymentAmount;
        Method = method;
        CreatedAt = DateTime.Now;
    }

    public void DisplayPayment()
    {
        Console.WriteLine($"Payment ID: {PaymentId}");
        Console.WriteLine($"Status: {Status}");
        Console.WriteLine($"Amount: {PaymentAmount:C}");
        Console.WriteLine($"Method: {Method}");
        Console.WriteLine($"Created at: {CreatedAt}");
    }

}
