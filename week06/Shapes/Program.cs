using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create various shapes
        List<Shape> shapes = new List<Shape>
        {
            new Square("Red", 5),
            new Rectangle("Blue", 4, 6),
            new Circle("Green", 3),
            new Square("Yellow", 2.5),
            new Circle("Purple", 4.2)
        };
        
        // Display shape information
        Console.WriteLine("Paper Shape Areas:");
        Console.WriteLine("==================\n");
        
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.GetColor()}");
            Console.WriteLine($"Shape Type:  {shape.GetType().Name}");
            Console.WriteLine($"Area:        {shape.GetArea():F2} units²");
            Console.WriteLine();
        }
    }
}