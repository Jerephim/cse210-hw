using System;

public class SwimmingActivity : Activity
{
    private int _laps;

    public SwimmingActivity(DateTime activityDate, int activityLength, int laps)
        : base(activityDate, activityLength)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        double distance = _laps * 50 / 1000.0 * 0.62;
        return Math.Round(distance, 1);
    }

    public override double GetSpeed()
    {
        double speed = (GetDistance() / _activityLength) * 60;
        return Math.Round(speed, 1);
    }

    public override double GetPace()
    {
        double pace = _activityLength / GetDistance();
        return Math.Round(pace, 1);
    }
}
