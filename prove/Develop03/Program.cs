using System;

class Program
{

    static void Main(string[] args)
    {
        Random random = new Random();
        string[] scripture = {"Trust", "in", "the", "Lord", "with", "all", "thine", "heart;", "and", "lean", "not", "unto", "thine", "own", "understanding.", "In", "all", "thy", "ways", "acknowledge", "him,", "and", "he", "shall", "direct", "thy", "paths."};
        string userInput = "";
        List<Int16> removedWords = new List<Int16>();
        bool repeat = true;
        int randomWord = 100;
        while(repeat == true)
        {
            Console.Clear();
            Console.Write("Proverbs 3:5-6 ");
            for(int x = 0; x < scripture.Length; x++)
            {
                int idx = removedWords.IndexOf((short)x);
                if(idx >= 0)
                {
                    for(int y = 0; y < scripture[x].Length; y++)
                        Console.Write("_");
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(scripture[x]+" ");
                }
            }   
            Console.WriteLine("");
            Console.Write("Press enter to contine or type 'quit' to finish: ");
            userInput = Console.ReadLine();
            if(userInput == "quit" || removedWords.Count >= scripture.Length)
            {
                repeat = false;
            }
            for(int x = 0; x < 3 && removedWords.Count < scripture.Length; x++)
            {
                bool needUnusedSlot = true;
                while(needUnusedSlot == true)
                {
                    randomWord = random.Next(scripture.Length);
                    int v = removedWords.IndexOf((short)randomWord);
                    if(v >= 0)
                    {
                        needUnusedSlot = true;
                    }
                    else
                    {
                        needUnusedSlot = false;
                    }
                }
                removedWords.Add((short)randomWord);
            }    
        }
    }
}