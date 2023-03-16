using System;
using System.Collections.Generic;
using System.IO;

namespace Journal
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Write a new journal entry");
                Console.WriteLine("2. See a list of all journal entries");
                Console.WriteLine("3. Read a specific journal entry");
                Console.WriteLine("4. Quit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Write a new journal entry:");
                        string entry = Console.ReadLine();
                        journal.WriteEntry(entry);
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("List of all journal entries:");
                        journal.ListEntries();
                        break;
                    case "3":
                        Console.WriteLine("Enter the date and time of the journal entry you want to read (yyyy-MM-dd HH:mm:ss):");
                        string date = Console.ReadLine();
                        Console.WriteLine(journal.ReadEntry(date));
                        break;
                    case "4":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }
    }

    class Journal
    {
        private readonly string fileName = "journal.txt";

        public void WriteEntry(string entry)
        {
            using (StreamWriter sw = File.AppendText(fileName))
            {
                sw.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}: {entry}");
            }
        }

        public void ListEntries()
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
            entries.Reverse();
            foreach (string entry in entries)
            {
                Console.WriteLine(entry);
            }
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
}
