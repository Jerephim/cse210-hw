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
            if (removedWords.Count >= scripture.WordCount())
            {
                break;
            }
            else
            {
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
    }
}

class Scripture
{
    private readonly List<Word> _words;

    public Scripture(List<string> wordTexts)
    {
        _words = new List<Word>();
        foreach (var wordText in wordTexts)
        {
            _words.Add(new Word(wordText));
        }
    }

    public int WordCount()
    {
        return _words.Count;
    }

    public int VisibleWordCount()
    {
        int count = 0;
        foreach (var word in _words)
        {
            if (word.Visible)
            {
                count++;
            }
        }
        return count;
    }

    public Word GetWord(int index)
    {
        return _words[index];
    }
}

class Word
{
    public readonly string Text;
    public bool Visible { get; set; }

    public Word(string text)
    {
        Text = text;
        Visible = true;
    }
}
