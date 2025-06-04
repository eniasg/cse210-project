using System

public class Fraction
{
    private int _top;
    private int _bottom;

    // Constructors
    public Fraction() : this(1, 1) { }  // Default to 1/1

    public Fraction(int top) : this(top, 1) { }  // Whole number fraction

    public Fraction(int top, int bottom)
    {
        _top = top;
        Bottom = bottom;  // Use property to include validation
    }

    // Getters and setters with validation
    public int Top
    {
        get => _top;
        set => _top = value;
    }

    public int Bottom
    {
        get => _bottom;
        set => _bottom = (value == 0) ? 1 : value;  // Prevent division by zero
    }

    // Representation methods
    public string GetFractionString() => $"{_top}/{_bottom}";
    
    public double GetDecimalValue() => (double)_top / _bottom;
}