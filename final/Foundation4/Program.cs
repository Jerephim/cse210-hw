using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        // Create instances of each activity type and add them to the list
        RunningActivity runningActivity = new RunningActivity(new DateTime(2023, 3, 30), 30, 3.0);
        activities.Add(runningActivity);

        CyclingActivity cyclingActivity = new CyclingActivity(new DateTime(2023, 3, 29), 45, 15.0);
        activities.Add(cyclingActivity);

        SwimmingActivity swimmingActivity = new SwimmingActivity(new DateTime(2023, 3, 28), 60, 40);
        activities.Add(swimmingActivity);

        // Iterate through the list and call the GetSummary method on each item and display the results
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
