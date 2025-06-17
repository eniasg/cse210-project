using System;
public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _amountCompleted++;
            if (_amountCompleted >= _target)
            {
                _isComplete = true;
                return _points + _bonus;
            }
            return _points;
        }
        return 0;
    }

    public override string GetDetailsString()
    {
        return $"{GetCheckbox()} {_shortName}: {_description} (Completed {_amountCompleted}/{_target} times)";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_bonus}|{_target}|{_amountCompleted}";
    }
}