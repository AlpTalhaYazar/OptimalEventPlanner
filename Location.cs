namespace OptimalEventPlanner;

public class LocationDuration(string from, string to, int durationMinutes)
{
    public string From { get; set; } = from;
    public string To { get; set; } = to;
    public int DurationMinutes { get; set; } = durationMinutes;
}