using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes; // duration in minutes

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime Date => _date;
    public int Minutes => _minutes;

    // Abstract methods to be overridden by derived classes
    public abstract double GetDistance(); // in miles or km
    public abstract double GetSpeed();    // in mph or kph
    public abstract double GetPace();     // in min per mile or min per km

    // Virtual method that can be overridden if needed
    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} {GetType().Name} ({_minutes} min) - " +
                $"Distance: {GetDistance():F1} {(IsMetric() ? "km" : "miles")}, " +
               $"Speed: {GetSpeed():F1} {(IsMetric() ? "kph" : "mph")}, " +
               $"Pace: {GetPace():F1} min per {(IsMetric() ? "km" : "mile")}";
    }

    // Helper method to determine if we're using metric (km) or imperial (miles)
    // For this program, we'll use miles (imperial)
    protected virtual bool IsMetric() => false;
}