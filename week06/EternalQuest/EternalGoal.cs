using System;
public class EternalGoal : Goal
{
    private int _timesCompleted;

    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _timesCompleted = 0;
    }

    public override int RecordEvent()
    {
        _timesCompleted++;
        return _points;
    }

    public override string GetDetailsString()
    {
        return $"{GetCheckbox()} {_shortName}: {_description} (completed {_timesCompleted} times)";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{_shortName}|{_description}|{_points}|{_timesCompleted}";
    }
}