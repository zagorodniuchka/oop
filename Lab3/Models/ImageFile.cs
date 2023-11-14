using System;
class ImageFile : FileBase
{
    public int Width { get; private set; }
    public int Height { get; private set; }

    public ImageFile(string fileName, int width, int height) : base(fileName)
    {
        Width = width;
        Height = height;
    }

    public override void GetInfo()
    {
        base.GetInfo();
        Console.WriteLine($"Image Size: {Width}x{Height}");
    }
}