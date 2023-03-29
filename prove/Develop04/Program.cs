using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Select an activity:\n1. Breathing\n2. Reflection\n3. Listing");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    BreathingActivity();
                    break;
                case 2:
                    ReflectionActivity();
                    break;
                case 3:
                    ListingActivity();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
    static int GetDuration()
    {
        int duration;
        while (true)
        {
            Console.Write("Enter the desired duration in seconds: ");
            if (int.TryParse(Console.ReadLine(), out duration) && duration > 0)
            {
                return duration;
            }
            Console.WriteLine("Invalid input. Please enter a positive integer value.");
        }
    }

    static void Delay(int seconds)
    {
        int milliseconds = seconds * 1000;
        Thread.Sleep(milliseconds);
    }
    static void BreathingActivity()
    {
        Console.WriteLine("Breathing Activity");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        int duration = GetDuration();

        Console.WriteLine("Get ready to begin...");
        Delay(3);

        Console.WriteLine("Breathe in...");
        Delay(4);

        Console.WriteLine("Hold breath...");
        Delay(7);

        Console.WriteLine("Breathe out...");
        Delay(8);
        duration -= 19;
        while (duration > 0)
        {
            Console.WriteLine("Breathe in...");
            Delay(4);

            Console.WriteLine("Hold breath...");
            Delay(7);

            Console.WriteLine("Breathe out...");
            Delay(8);

            duration -= 19;
        }

        Console.WriteLine("Good job! You have completed the Breathing Activity.");
        Delay(3);
    }
    static void Spinner()
    {
        string[] spinner = { "|", "/", "-", "\\" };
        int spinnerIndex = 0;
        for (int i = 0; i < 150; i++)
        {
            Console.Write(spinner[spinnerIndex % spinner.Length] + " ");
            spinnerIndex++;
            Thread.Sleep(100);
            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
        }
        Console.WriteLine();
    }
    static void ReflectionActivity()
    {
        Console.WriteLine("Reflection Activity");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life. For the best experience input a big number (greater than 300).");
        int duration = GetDuration();

        Console.WriteLine("Get ready to begin...");
        Delay(3);

        Random random = new Random();
        string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Thing of a time you felt powerful",
            "Think of a time where you felt calm",
        };
        string[] questions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
            };
        while (duration > 0)
        {
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine(prompt);
            Spinner();

            duration -= 15;

            foreach (string question in questions)
            {
                Console.Write(question);
                Spinner();
                duration -= 15;
                if (duration <= 0)
                {
                    break;
                }
            }
        }

        Console.WriteLine("Good job! You have completed the Reflection Activity for {0} seconds.", duration + (prompts.Length * (questions.Length + 1)) * 2);
        Delay(3);
    }

    static void ListingActivity()
    {
        Console.WriteLine("Listing Activity");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Console.WriteLine("What area would you like to focus on? (e.g. things you're grateful for, achievements, happy memories)");
        string focus = Console.ReadLine();
        Console.WriteLine("How many things would you like to list?");
        int times = int.Parse(Console.ReadLine());
        Console.WriteLine("Start listing {0}.", focus);

        int amount = 0;
        while (times > 0)
        {
            amount++;
            Console.Write(amount+ ". ");
            Console.ReadLine();

            times -= 1;
        }

        Console.WriteLine("Good job! You have listed {0} {1} in the Listing Activity.", amount, focus);
        Delay(3);
    }
}