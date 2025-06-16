public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) 
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        return GetPoints();
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString()
    {
        return base.GetDetailsString() + " [∞]";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName}|{_description}|{_points}";
    }
}