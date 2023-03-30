using System;
using System.Threading;

class Program
{
    private const int X = 15;

    static void Main(string[] args)
    {
        bool loop = true;
        while (loop)
        {
            Console.Write("Menu Options:\n  1. Start breathing activity\n  2. Start Reflecting activity\n  3. Start listing activity\n  4. Quit\nSelect a choice from the menu: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    BreathingActivity();
                    break;
                case 2:
                    Console.Clear();
                    ReflectionActivity();
                    break;
                case 3:
                    Console.Clear();
                    ListingActivity();
                    break;
                case 4:
                    Console.Clear();
                    loop = false;
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

    static void BreathingActivity()
    {
        Console.WriteLine("Welcome to the Breathing Activity.\n");
        Console.Write("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.\n\n How long, in seconds, would you like for your session? ");
        int duration = GetDuration();

        Console.Write("Get ready to begin...");
        Spinner(3);

        while (duration > 0)
        {
            Console.Write("Breathe in...");
            CountDown(4);
            Console.Write("");

            Console.Write("Hold breath...");
            CountDown(7);
            Console.Write("");

            Console.WriteLine("Breathe out...");
            CountDown(8);
            Console.Write("");

            duration -= 19;
        }

        Console.WriteLine("Well done!!\n\n You have completed the Breathing Activity.");
        CountDown(3);
        Console.Clear();
    }
    static void Spinner(int x)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        int spinnerIndex = 0;
        for (int i = 0; i < x*4; i++)
        {
            Console.Write(spinner[spinnerIndex % spinner.Length] + " ");
            spinnerIndex++;
            Thread.Sleep(250);
            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
        }
        Console.WriteLine();
    }

    static void CountDown(int x)
    {
        string[] countDown = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57" };
        x--;
        for (int i = x; i >= 0; i--)
        {
            Console.Write(countDown[i]);
            Thread.Sleep(1000);
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
        Console.WriteLine(" ");
    }
    static void ReflectionActivity()
    {
        Console.WriteLine("Welcome to the Reflecting Activity.\n\n");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life. ");
        Console.WriteLine("How long, in seconds, would you like for your session? ");
        int duration = GetDuration();
        int usedDuration = duration;
        Console.WriteLine("Get ready to begin...");
        CountDown(3);

        Random random = new Random();
        string[] prompts = {
            " --- Think of a time when you stood up for someone else. --- ",
            " --- Think of a time when you did something really difficult. --- ",
            " --- Think of a time when you helped someone in need. --- ",
            " --- Think of a time when you did something truly selfless. --- ",
            " --- Think of a time you felt powerful --- ",
            " --- Think of a time where you felt calm --- ",
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
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt + "\n");
        Console.WriteLine("When you have something in mind, press enter to continue.\n");
        foreach (string question in questions)
        {
            Console.Write(question);
            Spinner(X);
            usedDuration -= 15;
            if (usedDuration <= 0)
            {
                break;
            }
        }

        Console.WriteLine("Well done!!\n\n You have completed another {0} seconds of the Reflecting Activity");
        CountDown(3);
        Console.Clear();
    }

    static void ListingActivity()
    {
        Console.WriteLine("Welcome to the Listing Activity");
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
        CountDown(3);
        Console.Clear();
    }
}