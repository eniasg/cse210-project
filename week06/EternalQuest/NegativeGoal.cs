public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, string penalty) 
        : base(name, description, penalty) { }

    public override int RecordEvent()
    {
        return -GetPoints();  // Deduct points
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString()
    {
        return base.GetDetailsString() + " [⚠️ Penalty]";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_shortName}|{_description}|{_points}";
    }
}