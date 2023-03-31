public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int pointValue, bool isCompleted)
        : base(name, description, pointValue)
    {
        Completed = isCompleted;
    }

    public override string ToString()
    {
        return $"Simple,{Name},{Description},{PointValue},{Completed}";
    }

    public override void Complete()
    {
        base.Complete();
    }
}
