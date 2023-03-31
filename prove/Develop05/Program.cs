using System;

namespace GoalTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Goal> goals = FileHandler.LoadGoals();

            int totalPoints = FileHandler.LoadPoints();

            Console.WriteLine($"You have {totalPoints} points.");

            int choice = -1;

            while (choice != 6)
            {
                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Delete Goal");
                Console.WriteLine("5. Edit Total Points");
                Console.WriteLine("6. Quit.");

                Console.Write("\nSelect a choice from the menu: ");
                int.TryParse(Console.ReadLine(), out choice);

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        CreateNewGoal(goals);
                        break;
                    case 2:
                        ListGoals(goals, totalPoints);
                        break;
                    case 3:
                        RecordEvent(goals, ref totalPoints);
                        break;
                    case 4:
                        DeleteGoal(goals, ref totalPoints);
                        break;
                    case 5:
                        EditTotalPoints(ref totalPoints);
                        break;
                    case 6:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                FileHandler.SaveGoals(goals);
                FileHandler.SavePoints(totalPoints);
            }
        }
        static void DeleteGoal(List<Goal> goals, ref int totalPoints)
        {
            ListGoals(goals, totalPoints);
            Console.Write("Enter the number of the goal you want to delete: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= goals.Count)
            {
                goals.RemoveAt(index - 1);
                Console.WriteLine("Goal deleted.");
            }
            else
            {
                Console.WriteLine("Invalid goal number. Deletion cancelled.");
            }
        }

        static void EditTotalPoints(ref int totalPoints)
        {
            Console.Write($"You currently have {totalPoints} points.\nEnter the new total points value: ");
            if (int.TryParse(Console.ReadLine(), out int newTotalPoints))
            {
                totalPoints = newTotalPoints;
                Console.WriteLine($"Total points updated to {totalPoints}.");
            }
            else
            {
                Console.WriteLine("Invalid input. Total points update cancelled.");
            }
        }

        static void CreateNewGoal(List<Goal> goals)
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");

            Console.Write("Which type of goal would you like to create? ");
            int.TryParse(Console.ReadLine(), out int typeChoice);

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            int.TryParse(Console.ReadLine(), out int points);

            Goal newGoal;

            switch (typeChoice)
            {
                case 1:
                    newGoal = new SimpleGoal(name, description, points, false);
                    break;
                case 2:
                    newGoal = new EternalGoal(name, description, points, false);
                    break;
                case 3:
                    Console.Write("How many times must this goal be completed? ");
                    int.TryParse(Console.ReadLine(), out int targetCount);

                    Console.Write("How many points are earned per completion? ");
                    int.TryParse(Console.ReadLine(), out int pointsPerCompletion);

                    newGoal = new ChecklistGoal(name, description, points, targetCount, pointsPerCompletion, false);
                    break;
                default:
                    Console.WriteLine("Invalid type choice. Goal creation cancelled.");
                    return;
            }

            goals.Add(newGoal);
            Console.WriteLine($"The goal '{name}' has been added with {points} points.");
        }


        static void ListGoals(List<Goal> goals, int totalPoints)
        {

            Console.WriteLine($"Total Points: {totalPoints}\n");
            Console.WriteLine("Goals:");

            for (int i = 0; i < goals.Count; i++)
            {
                Goal goal = goals[i];

                string completed = goal.Completed ? "X" : " ";
                string goalDetails = $"{goal.Name} ({goal.Description})";

                if (goal is ChecklistGoal checklistGoal)
                {
                    goalDetails += $" - Completed {checklistGoal.TimesCompleted}/{checklistGoal.RequiredTimes} ({goal.PointValue} points)";
                }
                else if (goal is EternalGoal eternalGoal)
                {
                    goalDetails += $" - Completed {eternalGoal.TimesCompleted} times ({goal.PointValue} points)";
                }
                else if (goal is SimpleGoal)
                {
                    goalDetails += $" ({goal.PointValue} points)";
                }

                Console.WriteLine($"{i + 1}. [{completed}] {goalDetails}");
            }
        }


        static void RecordEvent(List<Goal> goals, ref int totalPoints)
        {
            Console.WriteLine("The goals are:");
            for (int i = 0; i < goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goals[i].Name}");
            }

            Console.Write("Which goal did you accomplish? ");
            int choice = int.Parse(Console.ReadLine());

            Goal selectedGoal = goals[choice - 1];
            selectedGoal.Complete();
            int points = selectedGoal.PointValue;
            Console.WriteLine($"You earned {points} points!");

            FileHandler.SaveGoals(goals);

            totalPoints += points;
            Console.WriteLine($"You have {totalPoints} points.");
        }
    }
}
