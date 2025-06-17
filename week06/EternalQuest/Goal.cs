using System;
public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    public string ShortName => _shortName;
    public int Points => _points;
    public bool IsComplete => _isComplete;

    public abstract int RecordEvent();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();

    protected string GetCheckbox()
    {
        return _isComplete ? "[X]" : "[ ]";
    }

    protected void SetComplete(bool complete)
    {
        _isComplete = complete;
    }
}