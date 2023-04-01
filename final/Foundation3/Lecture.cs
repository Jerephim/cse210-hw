public class Lecture : Event
{
    private string _speakerName;
    private int _capacity;

    public Lecture(string eventTitle, string eventDescription, DateTime eventDate, DateTime eventTime, Address eventAddress, string speakerName, int capacity)
        : base(eventTitle, eventDescription, eventDate, eventTime, eventAddress)
    {
        _speakerName = speakerName;
        _capacity = capacity;
    }

    public override string GetStandardDetails()
    {
        return FormatStandardDetails();
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\n" +
               $"Type: Lecture\n" +
               $"Speaker: {_speakerName}\n" +
               $"Capacity: {_capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Lecture\n" +
               $"Title: {EventTitle}\n" +
               $"Date: {EventDate.ToString("MM-dd-yyyy")}";
    }
}
