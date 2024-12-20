public class EventManager
{
    private List<string> _scheduledEvents;

    public EventManager()
    {
        _scheduledEvents = new List<string>();
    }

    public void ScheduleEvent(string eventDescription)
    {
        _scheduledEvents.Add(eventDescription);
        Console.WriteLine($"Event scheduled: {eventDescription}");
    }

    public void ExecuteEvent(string eventDescription)
    {
        if (_scheduledEvents.Contains(eventDescription))
        {
            Console.WriteLine($"Executing event: {eventDescription}");
            _scheduledEvents.Remove(eventDescription);
        }
        else
        {
            Console.WriteLine($"Event not found: {eventDescription}");
        }
    }

    public DateTime GetCurrentTime()
    {
        return DateTime.Now;
    }
}
