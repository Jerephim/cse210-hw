using System;

class BreathingActivity : Activity
{
    public override void Start()
    {
        base.Start();

        Console.WriteLine("Welcome to the Breathing Activity.\n");
        Console.Write("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.\n\n How long, in seconds, would you like for your session? ");
        int duration = GetDuration();
        int total = duration;
        while (duration > 0)
        {
            Console.Write("Breathe in...");
            CountDown(4);

            Console.Write("Hold breath...");
            CountDown(7);

            Console.Write("Breathe out...");
            CountDown(8);
            Console.WriteLine("");
            duration -= 19;
        }

        Console.WriteLine($"Well done!!\n\n You have completed another {total} seconds of the Breathing Activity.");
        Spinner(3);
        Console.Clear();
    }
}
