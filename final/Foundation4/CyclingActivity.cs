using System;

public class CyclingActivity : Activity
{
    private double _speed;

    public CyclingActivity(DateTime activityDate, int activityLength, double speed)
        : base(activityDate, activityLength)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        double distance = (_speed * _activityLength) / 60;
        return Math.Round(distance, 1);
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        double pace = _activityLength / GetDistance();
        return Math.Round(pace, 1);
    }
}
