using System.Collections.Generic;
using System.IO;

namespace GoalTracker
{
    public static class FileHandler
    {
        public static string GoalsFilePath = "goals.txt";
        public static string PointsFilePath = "points.txt";

        public static List<Goal> LoadGoals()
        {
            List<Goal> goals = new List<Goal>();

            if (File.Exists(GoalsFilePath))
            {
                using (StreamReader reader = new StreamReader(GoalsFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Goal goal = Goal.Parse(line);
                        if (goal != null)
                        {
                            goals.Add(goal);
                        }
                    }
                }
            }

            return goals;
        }

        public static void SaveGoals(List<Goal> goals)
        {
            using (StreamWriter writer = new StreamWriter(GoalsFilePath))
            {
                foreach (Goal goal in goals)
                {
                    writer.WriteLine(goal.ToString());
                }
            }
        }

        public static int LoadPoints()
        {
            int points = 0;

            if (File.Exists(PointsFilePath))
            {
                using (StreamReader reader = new StreamReader(PointsFilePath))
                {
                    string line;
                    if ((line = reader.ReadLine()) != null)
                    {
                        int.TryParse(line, out points);
                    }
                }
            }

            return points;
        }

        public static void SavePoints(int points)
        {
            using (StreamWriter writer = new StreamWriter(PointsFilePath))
            {
                writer.WriteLine(points.ToString());
            }
        }
    }
}
