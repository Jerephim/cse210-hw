using System.Collections.Generic;

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
