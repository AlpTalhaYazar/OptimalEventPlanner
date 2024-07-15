namespace OptimalEventPlanner;

public class ScheduledEventsResult(int eventCount, List<int> eventIds, int prioritySum)
{
    private int EventCount { get; set; } = eventCount;
    private List<int> EventIds { get; set; } = eventIds;
    private int PrioritySum { get; set; } = prioritySum;

    public override string ToString() =>
        $"""
         Katılınabilecek Maksimum Etkinlik Sayısı: {EventCount}
         Katılınabilecek Etkinliklerin ID'leri: {string.Join(", ", EventIds)}
         Toplam Değer: {PrioritySum}
         """;

    public void PrintResult() => Console.WriteLine(ToString());
}