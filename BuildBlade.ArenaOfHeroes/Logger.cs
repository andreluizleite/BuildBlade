public class Logger
{
    private List<string> _events;

    public Logger()
    {
        _events = new List<string>();
    }

    public void LogEvent(string eventMessage)
    {
        _events.Add(eventMessage);
    }

    public List<string> GetEvents()
    {
        return _events;
    }
}