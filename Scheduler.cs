namespace OptimalEventPlanner;

public class Scheduler(List<Event> events, List<LocationDuration> locationDurations)
{
    private readonly List<Event> _events = RemoveLowerPriorityEventsWithSameStartingDate(events).OrderBy(e => e.StartTime).ToList();

    private readonly List<LocationDuration> _locationDurations = locationDurations;

    public async Task<ScheduledEventsResult> MaximizeEventValue()
    {
        int eventCount = _events.Count;

        int[] maxValues = new int[eventCount];

        int[] previousEvent = new int[eventCount];

        for (int i = 0; i < eventCount; i++)
        {
            maxValues[i] = _events[i].Priority;
            previousEvent[i] = -1;
        }

        for (int i = 1; i < eventCount; i++)
        {
            for (int j = 0; j < i; j++)
            {
                int travelTime = _locationDurations?
                    .FirstOrDefault(ld => ld.From == _events[j].Location && ld.To == _events[i].Location)?
                    .DurationMinutes ?? 0;

                if (_events[j].EndTime.AddMinutes(travelTime) <= _events[i].StartTime
                    && maxValues[i] < maxValues[j] + _events[i].Priority)
                {
                    maxValues[i] = maxValues[j] + _events[i].Priority;
                    previousEvent[i] = j;
                }
            }
        }

        int optimalIndex = 0;
        for (int i = 1; i < eventCount; i++)
        {
            if (maxValues[i] > maxValues[optimalIndex])
            {
                optimalIndex = i;
            }
        }

        List<int> optimalEventIds = new List<int>();
        for (int i = optimalIndex; i != -1; i = previousEvent[i])
        {
            optimalEventIds.Add(_events[i].Id);
        }

        optimalEventIds.Reverse();

        int totalOptimalValue = maxValues[optimalIndex];

        return await Task.FromResult(new ScheduledEventsResult(optimalEventIds.Count, optimalEventIds,
            totalOptimalValue));
    }

    private static List<Event> RemoveLowerPriorityEventsWithSameStartingDate(List<Event> events)
    {
        var eventsGroupedByStartTime = events.GroupBy(e => e.StartTime);

        var filteredEvents = new List<Event>();

        foreach (var group in eventsGroupedByStartTime)
        {
            filteredEvents.Add(group.OrderByDescending(e => e.Priority).First());
        }

        return filteredEvents;
    }
}