public class ProgressGoal : Goal
{
    private int _currentProgress;
    private int _target;
    
    public ProgressGoal(string name, string description, string pointsPerStep, 
                       int target) : base(name, description, pointsPerStep)
    {
        _currentProgress = 0;
        _target = target;
    }

    public override int RecordEvent()
    {
        if (_currentProgress < _target)
        {
            _currentProgress++;
            return GetPoints();
        }
        return 0;
    }

    public override bool IsComplete() => _currentProgress >= _target;

    public override string GetDetailsString()
    {
        return base.GetDetailsString() + 
               $" - Progress: {_currentProgress}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ProgressGoal:{_shortName}|{_description}|{_points}|{_target}|{_currentProgress}";
    }
}