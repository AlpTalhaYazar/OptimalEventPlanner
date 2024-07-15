namespace OptimalEventPlanner;

public class Event(int id, DateTime startTime, DateTime endTime, string location, int priority)
{
    public int Id { get; set; } = id;
    public DateTime StartTime { get; set; } = startTime;
    public DateTime EndTime { get; set; } = endTime;
    public string Location { get; set; } = location;
    public int Priority { get; set; } = priority;
}