using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var random = new Random();
        var scripture = new Scripture(new List<string> {
            "Trust", "in", "the", "Lord", "with", "all", "thine", "heart;", "and", "lean", "not", "unto", "thine", "own", "understanding.", "In", "all", "thy", "ways", "acknowledge", "him,", "and", "he", "shall", "direct", "thy", "paths."
        });
        var userInput = "";
        var removedWords = new List<int>();
        var repeat = true;

        while (repeat)
        {
            Console.Clear();
            Console.Write("Proverbs 3:5-6 ");
            for (int i = 0; i < scripture.WordCount(); i++)
            {
                var word = scripture.GetWord(i);
                if (removedWords.Contains(i) || !word.Visible)
                {
                    for (int j = 0; j < word.Text.Length; j++)
                    {
                        Console.Write("_");
                    }
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(word.Text + " ");
                }
            }
            Console.WriteLine("");
            Console.Write("Press enter to continue or type 'quit' to finish: ");
            userInput = Console.ReadLine();

            if (userInput == "quit")
            {
                repeat = false;
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    int randomWord;
                    do
                    {
                        randomWord = random.Next(scripture.WordCount());
                    }
                    while (removedWords.Contains(randomWord) || !scripture.GetWord(randomWord).Visible);

                    removedWords.Add(randomWord);
                    scripture.GetWord(randomWord).Visible = false;
                }
            }
        }

        Console.Clear();
        Console.Write("Proverbs 3:5-6 ");
        for (int i = 0; i < scripture.WordCount(); i++)
        {
            var word = scripture.GetWord(i);
            for (int j = 0; j < word.Text.Length; j++)
            {
                Console.Write("_");
            }
            Console.Write(" ");
        }
        Console.WriteLine("");
        Console.WriteLine("Press enter to finish.");
    }
}
