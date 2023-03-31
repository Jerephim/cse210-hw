public class ChecklistGoal : Goal
{
    public int TimesCompleted { get; set; }
    public int RequiredTimes { get; set; }

    public ChecklistGoal(string name, string description, int pointValue, int requiredTimes, int timesCompleted, bool isCompleted)
        : base(name, description, pointValue)
    {
        RequiredTimes = requiredTimes;
        TimesCompleted = timesCompleted;
        Completed = isCompleted;
    }

    public override string ToString()
    {
        return $"Checklist,{Name},{Description},{PointValue},{Completed},{RequiredTimes},{TimesCompleted}";
    }

    public override void Complete()
    {
        TimesCompleted++;
        if (TimesCompleted >= RequiredTimes)
        {
            base.Complete();
        }
    }
}
