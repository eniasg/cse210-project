using System;
public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        return -_points; // Deduct points for negative habits
    }

    public override string GetDetailsString()
    {
        return $"{GetCheckbox()} {_shortName}: {_description} (Warning: Deducts points!)";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal|{_shortName}|{_description}|{_points}";
    }
}