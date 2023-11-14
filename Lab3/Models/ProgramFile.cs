using System;
class ProgramFile : FileBase
{
    public int LineCount { get; private set; }
    public int ClassCount { get; private set; }
    public int MethodCount { get; private set; }

    public ProgramFile(string fileName, int lines, int classes, int methods) : base(fileName)
    {
        LineCount = lines;
        ClassCount = classes;
        MethodCount = methods;
    }

    public override void GetInfo()
    {
        base.GetInfo();
        Console.WriteLine($"Line Count: {LineCount}");
        Console.WriteLine($"Class Count: {ClassCount}");
        Console.WriteLine($"Method Count: {MethodCount}");
    }
}