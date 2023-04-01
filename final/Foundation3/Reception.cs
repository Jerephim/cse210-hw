public class Reception : Event
{
    private string _rsvpEmail;

    public Reception(string eventTitle, string eventDescription, DateTime eventDate, DateTime eventTime, Address eventAddress, string rsvpEmail)
        : base(eventTitle, eventDescription, eventDate, eventTime, eventAddress)
    {
        _rsvpEmail = rsvpEmail;
    }

    public override string GetStandardDetails()
    {
        return FormatStandardDetails();
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\n" +
               $"Type: Reception\n" +
               $"RSVP Email: {_rsvpEmail}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Reception\n" +
               $"Title: {EventTitle}\n" +
               $"Date: {EventDate.ToString("MM-dd-yyyy")}";
    }
}
