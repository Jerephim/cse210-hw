using System;

public class RunningActivity : Activity
{
    private double _distance;

    public RunningActivity(DateTime activityDate, int activityLength, double distance)
        : base(activityDate, activityLength)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        double speed = (_distance / _activityLength) * 60;
        return Math.Round(speed, 1);
    }

    public override double GetPace()
    {
        double pace = _activityLength / _distance;
        return Math.Round(pace, 1);
    }
}
