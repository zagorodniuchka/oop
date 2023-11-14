using System;
class TextFile : FileBase
{
    public int LineCount { get; private set; }
    public int WordCount { get; private set; }
    public int CharacterCount { get; private set; }

    public TextFile(string fileName, int lines, int words, int characters) : base(fileName)
    {
        LineCount = lines;
        WordCount = words;
        CharacterCount = characters;
    }

    public override void GetInfo()
    {
        base.GetInfo();
        Console.WriteLine($"Line Count: {LineCount}");
        Console.WriteLine($"Word Count: {WordCount}");
        Console.WriteLine($"Character Count: {CharacterCount}");
    }
}