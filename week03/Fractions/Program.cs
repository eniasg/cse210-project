using System;

class Program
{
    static void Main(string[] args)
    {
        // Create fractions using all constructors
        Fraction f1 = new Fraction();       // 1/1
        Fraction f2 = new Fraction(5);      // 5/1
        Fraction f3 = new Fraction(3, 4);   // 3/4
        Fraction f4 = new Fraction(1, 3);   // 1/3

        // Test getters/setters
        f1.Top = 2;
        f1.Bottom = 3;
        Console.WriteLine($"Modified fraction: {f1.GetFractionString()}");

        // Display representations
        DisplayFraction(f1);  // 2/3
        DisplayFraction(f2);  // 5/1
        DisplayFraction(f3);  // 3/4
        DisplayFraction(f4);  // 1/3
    }

    static void DisplayFraction(Fraction f)
    {
        Console.WriteLine(f.GetFractionString());
        Console.WriteLine(f.GetDecimalValue());
        Console.WriteLine();
    }
}