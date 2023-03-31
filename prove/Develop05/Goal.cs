public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int PointValue { get; set; }
    public bool Completed { get; set; }

    protected Goal(string name, string description, int pointValue)
    {
        Name = name;
        Description = description;
        PointValue = pointValue;
        Completed = false;
    }

    protected Goal(string name, string description, string x, int pointValue)
    {

    }
    public virtual void Complete()
    {
        Completed = true;
    }

    public abstract override string ToString();


    public static Goal Parse(string line)
        {
            string[] values = line.Split(',');
            string goalType = values[0];
            string name = values[1];
            string description = values[2];
            int pointValue = int.Parse(values[3]);
            bool isCompleted = bool.Parse(values[4]);

            switch (goalType)
            {
                case "Simple":
                    return new SimpleGoal(name, description, pointValue, isCompleted);
                case "Eternal":
                    return new EternalGoal(name, description, pointValue, isCompleted);
                case "Checklist":
                    int targetCount = int.Parse(values[5]);
                    int completionCount = int.Parse(values[6]);
                    return new ChecklistGoal(name, description, pointValue, targetCount, completionCount, isCompleted);
                default:
                    throw new ArgumentException("Invalid goal type specified in file.");
            }
        }
}