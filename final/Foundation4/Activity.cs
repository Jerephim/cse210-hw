using System;

public abstract class Activity
{
    private DateTime _activityDate;
    public int _activityLength;

    public Activity(DateTime activityDate, int activityLength)
    {
        _activityDate = activityDate;
        _activityLength = activityLength;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        string activityType = GetType().Name;
        if(activityType == "RunningActivity")
        {
            activityType = "Running";
        }
        else if(activityType == "CyclingActivity")
        {
            activityType = "Cycling";
        }
        else if(activityType == "SwimmingActivity")
        {
            activityType = "Swimming";
        }
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        string summary = $"{_activityDate.ToString("dd MMM yyyy")} {activityType} ({_activityLength} min) - ";
        summary += $"Distance: {distance} miles, Speed: {speed} mph, Pace: {pace} min per mile";

        return summary;
    }
}
