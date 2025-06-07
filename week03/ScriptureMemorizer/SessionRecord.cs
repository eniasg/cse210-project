public class SessionRecord
{
    public string ScriptureId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int Difficulty { get; set; }
    public bool Completed { get; set; }
    public TimeSpan Duration => EndTime - StartTime;
}