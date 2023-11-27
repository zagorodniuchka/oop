using System;
using System.Text.RegularExpressions;

namespace Lab2
{
	public class InfoProgramFiles : InfoAllFiles
	{
        private int lines = 0, classes = 0, methods = 0;
        public void GetCountLines(string fileName) 
        {
            lines = File.ReadLines(Path.Combine(filePath, fileName)).Count();
        }
        public void GetCountClasses(string fileName)
        {
            string[] lines = File.ReadAllLines(Path.Combine(filePath, fileName));

            int classCount = 0;
            bool insideClass = false;

            foreach (string line in lines)
            {
                // Check if the line starts a class definition
                if (Regex.IsMatch(line, @"^\s*class\s+[A-Za-z_][A-Za-z0-9_]*(?:\s*\(.+\))?\s*:$"))
                {
                    classCount++;
                    insideClass = true;
                }
                // Check if the line ends a class definition
                else if (insideClass && Regex.IsMatch(line, @"^\s*[^#]*:\s*$"))
                {
                    insideClass = false;
                }
            }
            classes = classCount;
        }

        public void GetCountMethodsJava(string fileName)
        {
            string code = File.ReadAllText(Path.Combine(filePath, fileName));
            string pattern = @"(\bpublic|\bprivate|\bprotected|\binternal)?\s+\w+\s+\w+\s*\([^)]*\)\s*{";

            MatchCollection matches = Regex.Matches(code, pattern);
            methods = matches.Count();

        }

        public void GetCountMethodsPython(string fileName)
        {
            string code = File.ReadAllText(Path.Combine(filePath, fileName));
            string pattern = @"(\bdef\s+\w+\s*\([^)]*\):)";
            MatchCollection matches = Regex.Matches(code, pattern);
            methods = matches.Count();

        }
        public void PrintProgramFileInfo(string fileName)
        {
            PrintInfoSpecificFile(Path.Combine(filePath, fileName));
            Console.WriteLine($"Number of lines: {lines}");
            Console.WriteLine($"Number of classes: {classes}");
            Console.WriteLine($"Number of methods: {methods}");
        }
    }
}
