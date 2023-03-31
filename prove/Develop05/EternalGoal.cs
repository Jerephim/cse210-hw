public class EternalGoal : Goal
{
    public int TimesCompleted { get; set; }

    public EternalGoal(string name, string description, int pointValue, bool isCompleted)
        : base(name, description, pointValue)
    {
        Completed = isCompleted;
    }
    public override string ToString()
    {
        return $"Eternal,{Name},{Description},{PointValue},{Completed},{TimesCompleted}";
    }

    public override void Complete()
    {
        TimesCompleted++;
    }
}