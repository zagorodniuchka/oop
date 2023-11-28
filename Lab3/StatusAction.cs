using System;
using System.IO;

namespace Lab2
{
	public class StatusAction
	{
		protected string filePath = @"TestOOP";
		public void PrintStatus(DateTime snapshotTime, List<string> previousFiles) 
		{
			string[] files = Directory.GetFiles(filePath);
			List<string> currentFiles = files.ToList();

			foreach (var item in currentFiles)
			{
				FileInfo fileInfo = new FileInfo(item);
				if (fileInfo.LastWriteTime > snapshotTime )
				{
					Console.WriteLine(fileInfo.LastWriteTime);
					Console.WriteLine(fileInfo.Name + " - Changed");
				}
				else if(!previousFiles.Contains(fileInfo.Name))
				{
					Console.WriteLine(fileInfo.Name + " - Added");
				}
				else
				{
					Console.WriteLine(fileInfo.Name + " - Not Changed");
				}
			}
			foreach (var item in previousFiles) 
			{
				FileInfo fileInfo = new FileInfo(item);
				int countMatches = 0;
				foreach (var file in currentFiles) 
				{
					FileInfo curentFile = new FileInfo(file);
					if (fileInfo.Name == curentFile.Name) countMatches += 1;
				}
				if (countMatches != 1) Console.WriteLine(fileInfo.Name+" - Deleted");
			}
		}
	}
}
