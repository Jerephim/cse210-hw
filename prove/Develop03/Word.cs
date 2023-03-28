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
