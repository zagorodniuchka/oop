using System;
using System.IO;

namespace Lab2
{
    public class InfoImageFiles : InfoAllFiles
    {
        public void PrintImageSize(string fileName)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "TestOOP", fileName);

            PrintInfoSpecificFile(filePath);

            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] header = new byte[24]; // Minimum size for common image formats

                    fs.Read(header, 0, 24);

                    int width = header[18] + (header[19] << 8);
                    int height = header[22] + (header[23] << 8);

                    Console.WriteLine($"Image size: {width}x{height}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading image size: {ex.Message}");
            }
        }
    }
}
