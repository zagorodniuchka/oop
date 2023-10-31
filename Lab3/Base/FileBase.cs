using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Base class to represent a file
class FileBase
{
    public string FileName { get; protected set; }
    public DateTime CreatedTime { get; protected set; }
    public DateTime LastModifiedTime { get; protected set; }

    public FileBase(string fileName)
    {
        FileName = fileName;
        CreatedTime = DateTime.Now;
        LastModifiedTime = DateTime.Now;
    }

    // Method to update the last modified time
    public void Commit()
    {
        LastModifiedTime = DateTime.Now;
    }

    // Method to get general information about the file
    public virtual void GetInfo()
    {
        Console.WriteLine($"File Name: {FileName}");
        Console.WriteLine($"Created Time: {CreatedTime}");
        Console.WriteLine($"Last Modified Time: {LastModifiedTime}");
    }
}
