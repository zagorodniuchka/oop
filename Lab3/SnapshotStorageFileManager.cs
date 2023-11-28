using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab2
{
	public class SnapshotStorageFileManager
	{
		private string fileName = "Snapshots.txt";
		private string filePath = @"TestOOP";

		public void StoreSnapshot(DateTime snapshotTime) 
		{
			string FMT = "O";
			string contentToSave = snapshotTime.ToString(FMT)+"\n";
			string[] files = Directory.GetFiles(filePath);
			foreach (var item in files) 
			{
				FileInfo fileInfo = new FileInfo(item);
				contentToSave += fileInfo.Name + "\n";	
			}
			File.WriteAllText(fileName, contentToSave);
		}
		public void ExtractLastSnapshot(DateTime snapshotTime)
		{
			string FMT = "O";
			string[] contentToExtract = File.ReadAllLines(fileName);
			snapshotTime = DateTime.ParseExact(contentToExtract[0], FMT, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
			Console.WriteLine("Created snapshot at: " + snapshotTime);
		}
		public void ExtractSavedFiles(List<string> savedFiles) 
		{
			string[] contentToExtract = File.ReadAllLines(fileName);
			for (int i = 1; i < contentToExtract.Length; i++)
			{
				savedFiles.Add(contentToExtract[i]);
			}
		}
	}
}