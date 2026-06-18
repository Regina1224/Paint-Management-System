using System;

namespace PaintManagementSystem.Models;

public class PaintSpecification
{
    // props
    public string Color{get; set;}
    public int SizeInLiters{get; set; }

    // constructor
    public PaintSpecification(string color, int sizeInLiters)
    {
        Color = color;
        SizeInLiters = sizeInLiters;
    }

    // method
    public void DisplaySpecification()
    {
        Console.WriteLine($"Paint color: {Color}, Paint size: {SizeInLiters}");
    }


}
