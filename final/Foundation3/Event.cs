using System;

public abstract class Event
{
    private string _eventTitle;
    private string _eventDescription;
    private DateTime _eventDate;
    private DateTime _eventTime;
    private Address _eventAddress;

    public Event(string eventTitle, string eventDescription, DateTime eventDate, DateTime eventTime, Address eventAddress)
    {
        _eventTitle = eventTitle;
        _eventDescription = eventDescription;
        _eventDate = eventDate;
        _eventTime = eventTime;
        _eventAddress = eventAddress;
    }

    public abstract string GetStandardDetails();
    public abstract string GetFullDetails();
    public abstract string GetShortDescription();
    protected string EventTitle => _eventTitle;
    protected DateTime EventDate => _eventDate;

    protected string FormatStandardDetails()
    {
        return $"Title: {_eventTitle}\n" +
               $"Description: {_eventDescription}\n" +
               $"Date: {_eventDate.ToString("MM-dd-yyyy")}\n" +
               $"Time: {_eventTime.ToString("HH:mm")}\n" +
               $"Address: {_eventAddress.ToString()}";
    }
}
