using System;
namespace Lab2
{
    public class InfoAllFiles
    {
        protected string filePath = @"TestOOP/";

        public void PrintInfoFiles()
        {
            string[] files = Directory.GetFiles(filePath);
            foreach (var item in files)
            {
                FileInfo fileInfo = new FileInfo(item);
                Console.WriteLine("File Name: " + fileInfo.Name);
                Console.WriteLine("Extension: " + fileInfo.Extension);
                Console.WriteLine("Created: " + fileInfo.CreationTime);
                Console.WriteLine("Last Updated: " + fileInfo.LastWriteTime);
            }
        }
        public void PrintInfoSpecificFile(string fileName)
        {
            FileInfo fileInfo = new FileInfo(Path.Combine(filePath, fileName));
            Console.WriteLine("File Name: " + fileInfo.Name);
            Console.WriteLine("Extension: " + fileInfo.Extension);
        }
    }
}