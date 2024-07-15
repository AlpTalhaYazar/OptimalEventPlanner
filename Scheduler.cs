namespace OptimalEventPlanner;

public class Scheduler(List<Event> events, List<LocationDuration> locationDurations)
{
    private readonly List<Event> _events = RemoveLowerPriorityEvents(events).OrderBy(e => e.StartTime).ToList();
    private readonly List<LocationDuration> _locationDurations = locationDurations;
}