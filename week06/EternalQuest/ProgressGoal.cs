using System;
public class ProgressGoal : Goal
{
    private int _currentProgress;
    private int _targetProgress;
    private int _progressPoints;

    public ProgressGoal(string name, string description, int completionPoints, int progressPoints, int targetProgress)
        : base(name, description, completionPoints)
    {
        _currentProgress = 0;
        _targetProgress = targetProgress;
        _progressPoints = progressPoints;
    }

    public override int RecordEvent()
    {
        _currentProgress++;
        if (_currentProgress >= _targetProgress)
        {
            _isComplete = true;
            return _points;
        }
        return _progressPoints;
    }

    public override string GetDetailsString()
    {
        return $"{GetCheckbox()} {_shortName}: {_description} (Progress: {_currentProgress}/{_targetProgress})";
    }

    public override string GetStringRepresentation()
    {
        return $"ProgressGoal|{_shortName}|{_description}|{_points}|{_progressPoints}|{_targetProgress}|{_currentProgress}";
    }
}