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

            Console.Write("Hold breath...");
            CountDown(7);

            Console.Write("Breathe out...");
            CountDown(8);
            Console.WriteLine("");
            duration -= 19;
        }

        Console.WriteLine("Well done!!\n\n You have completed the Breathing Activity.");
        Spinner(3);
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
        Console.Read();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        CountDown(5);
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
        Spinner(3);
        Console.Clear();
    }

    static void ListingActivity()
    {
        Random random = new Random();
        string[] prompts = 
        {
            "---What are some times that you have felt joy?---",
            "---What are some things you enjoy eating?---",
            "---What are some experiences that have helped you grow as a person?---",
            "---What are some things that make you feel grateful?---",
            "---What are some activities you enjoy doing in your free time?---",
            "---What are some things that you are curious about?---",
            "---What are some things you've done that you are proud of?---",
            "---What are some things that you've learned recently?---",
            "---What are some things that you are looking forward to?---",
            "---What are some things that inspire you?---",
            "---What are some things that you find relaxing?---",
            "---What are some things that you find challenging?---",
            "---What are some things that you find fulfilling?---",
            "---What are some things that you find frustrating?---",
            "---What are some things that you find funny?---",
            "---What are some things that you find beautiful?---",
            "---What are some things that you find meaningful?---",
            "---What are some things that you find exciting?---",
            "---What are some things that you find scary?---",
            "---What are some things that you find surprising?---",
            "---What are some things that you find confusing?---",
            "---What are some things that you find annoying?---",
            "---What are some things that you find interesting?---",
            "---What are some things that you find enjoyable?---",
            "---What are some things that you find challenging?---",
            "---What are some things that you find worthwhile?---",
            "---What are some things that you find frustrating?---",
            "---What are some things that you find rewarding?---",
            "---What are some things that you find inspiring?---",
            "---What are some things that you find humbling?---",
            "---What are some things that you find overwhelming?---",
            "---What are some things that you find peaceful?---",
            "---What are some things that you find hopeful?---",
            "---What are some things that you find motivating?---",
            "---What are some things that you find satisfying?---",
            "---What are some things that you find empowering?---",
            "---What are some things that you find fascinating?---",
            "---What are some things that you find amusing?---",
            "---What are some things that you find impressive?---",
            "---What are some things that you find heartwarming?---",
            "---What are some things that you find thought-provoking?---"
        };
        string prompt = prompts[random.Next(prompts.Length)];

        Console.WriteLine("Welcome to the Listing Activity");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.\n");
        Console.Write("How long, in seconds, would you like for your session? ");
        int timeLimit = int.Parse(Console.ReadLine());

        DateTime deadline = DateTime.Now.AddSeconds(timeLimit);

        Console.Write("Get ready...");
        Spinner(3);

        Console.WriteLine("List as many responses as you can to the following prompt:\n\n" + prompt + "\n");
        Console.Write("You may begin in: ");
        CountDown(5);

        int x = 0;
        while (DateTime.Now < deadline)
        {
            Console.Write("> ");
            Console.ReadLine();
            x++;
        }

        Console.WriteLine("Well done!\n\n You have listed " + x + " items.");
        Spinner(3);
        Console.Clear();
    }
}