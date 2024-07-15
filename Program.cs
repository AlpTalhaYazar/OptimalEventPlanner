namespace OptimalEventPlanner;

class Program
{
    static void Main(string[] args)
    {
        List<Event> events = new()
        {
            new Event(1, DateTime.Parse("10:00"), DateTime.Parse("12:00"), "A", 50),
            new Event(2, DateTime.Parse("10:00"), DateTime.Parse("11:00"), "B", 30),
            new Event(3, DateTime.Parse("11:30"), DateTime.Parse("12:30"), "A", 40),
            new Event(4, DateTime.Parse("14:30"), DateTime.Parse("16:00"), "C", 70),
            new Event(5, DateTime.Parse("14:25"), DateTime.Parse("15:30"), "B", 60),
            new Event(6, DateTime.Parse("13:00"), DateTime.Parse("14:00"), "D", 80)
        };

        List<LocationDuration> locationsDurations = new()
        {
            new LocationDuration("A", "B", 15),
            new LocationDuration("A", "C", 20),
            new LocationDuration("A", "D", 10),
            new LocationDuration("B", "C", 5),
            new LocationDuration("B", "D", 25),
            new LocationDuration("C", "D", 25)
        };

        var scheduler = new Scheduler(events, locationsDurations);
        ScheduledEventsResult scheduledEventsResult = scheduler.MaximizeEventValue().Result;

        scheduledEventsResult.PrintResult();
    }
}