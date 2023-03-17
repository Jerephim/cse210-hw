using System;
using System.Collections.Generic;
using System.IO;

namespace Journal
{
    class Journal
    {
        private readonly string fileName;

        public Journal(string fileName)
        {
            this.fileName = fileName;
        }

        public void WriteEntry(string entry)
        {
            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}: {entry}");
            }
        }

        public List<string> ListEntries()
        {
            List<string> entries = new List<string>();
            using (StreamReader sr = File.OpenText(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    entries.Add(line);
                }
            }
            return entries;
        }

        public string ReadEntry(string date)
        {
            using (StreamReader sr = File.OpenText(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith(date))
                    {
                        return line;
                    }
                }
            }
            return "Journal entry not found.";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the file name for your journal.");
            Console.Write(">>> ");
            string fileName = Console.ReadLine();

            Journal journal = new Journal(fileName);
            bool quit = false;

            while (!quit)
            {
                
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Write a new journal entry");
                Console.WriteLine("2. See a list of all journal entries");
                Console.WriteLine("3. Read a specific journal entry");
                Console.WriteLine("4. Get a random interesting question");
                Console.WriteLine("5. Clear");
                Console.WriteLine("6. Quit");
                Console.Write(">>> ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Write a new journal entry:");
                        Console.Write(">>> ");
                        string entry = Console.ReadLine();
                        journal.WriteEntry(entry);
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("List of all journal entries:");
                        List<string> entries = journal.ListEntries();
                        foreach (string e in entries)
                        {
                            Console.WriteLine(e);
                            Console.WriteLine("*********************");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Enter the date and time of the journal entry you want to read (yyyy-MM-dd HH:mm:ss)");
                        Console.Write(">>> ");
                        string date = Console.ReadLine();
                        Console.WriteLine(journal.ReadEntry(date));
                        break;
                    case "4":
                        Console.WriteLine("Here's your random interesting question:");
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine(GetRandomInterestingQuestion());
                        Console.WriteLine("---------------------------------------");
                        break;
                    case "5":
                        Console.Clear();
                        break;
                    case "6":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }

        static string GetRandomInterestingQuestion()
        {
            List<string> questions = new List<string>()
            {
                "What was the best part of your day today?",
                "Did you feel insecure about something today?",
                "What is something that you're looking forward to?",
                "What is a dream you had recently?",
                "What is a recent accomplishment that you're proud of?",
                "What is a challenge you're currently facing?",
                "What is something that you learned today?",
                "What is something that you regret?",
                "What is a personal goal that you're working towards?",
                "What is something that made you laugh today?",
                "What is something that made you feel grateful today?",
                "What is a recent decision that you made?",
                "What is a mistake that you made recently?",
                "What is something that you're curious about?",
                "What is something that you find challenging in your relationships?",
                "What is a recent book or article that you read?",
                "What is something that you've been procrastinating on?",
                "What is something that you're passionate about?",
                "What is something that you would like to learn more about?",
                "What is a recent change in your life?",
                "What is something you wish you could tell your past self?",
                "What is something you wish you could tell your future self?",
                "What is a recent movie or TV show you watched?",
                "What is something you're struggling with?",
                "What is a new hobby you've picked up?",
                "What is something you've always wanted to try?",
                "What is a decision you've been putting off?",
                "What is something that inspired you recently?",
                "What is something that surprised you recently?",
                "What is a personal accomplishment you're proud of?",
                "What is something you're excited about for the future?",
                "What is something you're worried about for the future?",
                "What is a recent conversation you had that impacted you?",
                "What is something you've been avoiding?",
                "What is something you've been procrastinating on?",
                "What is a skill you want to learn?",
                "What is something you've been putting off for too long?",
                "What is a recent challenge you overcame?",
                "What is a favorite childhood memory?",
                "What is something you're grateful for?",
                "What is something you're currently obsessed with?",
                "What is a place you want to travel to?",
                "What is a new food or recipe you tried?",
                "What is something you learned from a recent mistake?",
                "What is something you wish you could do more often?",
                "What is a recent project you completed?",
                "What is a personal belief you hold strongly?",
                "What is something you're proud of but don't talk about much?",
                "What is a small goal you achieved today?",
                "What is something you've been avoiding but need to do?",
                "What is something you've been meaning to tell someone?",
                "What is a recent act of kindness you witnessed?",
                "What is something you've learned from a recent failure?",
                "What is a favorite quote or saying of yours?",
                "What is something that motivates you?",
                "What is something you would change about yourself?",
                "What is something you're currently trying to improve?",
                "What is a recent moment of clarity you had?",
                "What is a recent piece of advice you received?",
                "What is a recent accomplishment you're grateful for?",
                "What is something you're currently trying to overcome?",
                "What is something you're excited about for tomorrow?"
            };

            Random random = new Random();
            int index = random.Next(questions.Count);
            return questions[index];
        }
    }
}


