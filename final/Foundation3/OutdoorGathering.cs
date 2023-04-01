public class OutdoorGathering : Event
{
    private string _weatherForecast;

    public OutdoorGathering(string eventTitle, string eventDescription, DateTime eventDate, DateTime eventTime, Address eventAddress, string weatherForecast)
        : base(eventTitle, eventDescription, eventDate, eventTime, eventAddress)
    {
        _weatherForecast = weatherForecast;
    }

    public override string GetStandardDetails()
    {
        return FormatStandardDetails();
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\n" +
               $"Type: Outdoor Gathering\n" +
               $"Weather Forecast: {_weatherForecast}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Outdoor Gathering\n" +
               $"Title: {EventTitle}\n" +
               $"Date: {EventDate.ToString("MM-dd-yyyy")}";
    }
}
