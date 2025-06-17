using System;
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            SetComplete(true);
            return _points;
        }
        return 0;
    }

    public override string GetDetailsString()
    {
        return $"{GetCheckbox()} {_shortName}: {_description}";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{_shortName}|{_description}|{_points}|{IsComplete}";
    }
}