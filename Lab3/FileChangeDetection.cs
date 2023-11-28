using System;
using Lab2;
using System.Threading;

namespace Lab2
{
	public class FileChangeDetection : StatusAction
	{
		CommitForChangeDetection commit = new CommitForChangeDetection();
		private DateTime snapshotTime = DateTime.Now;
		private Timer detectionTimer;
		SnapshotStorageFileManager snapshotFileManager = new SnapshotStorageFileManager();
		private ManualResetEvent stopEvent = new ManualResetEvent(false);

		// overriding
		new private void PrintStatus(DateTime snapshotTime, List<string> previousFiles)
		{
			string[] files = Directory.GetFiles(filePath);
			List<string> currentFiles = files.ToList();

			foreach (var item in currentFiles)
			{
				FileInfo fileInfo = new FileInfo(item);
				if (fileInfo.LastWriteTime > snapshotTime && previousFiles.Contains(fileInfo.Name))
				{
					Console.WriteLine("\n>>> " + fileInfo.Name + " - Changed");
				}
				else if (!previousFiles.Contains(fileInfo.Name))
				{
					Console.WriteLine("\n>>> " + fileInfo.Name + " - Added");
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
				if (countMatches != 1) Console.WriteLine("\n>>> " + fileInfo.Name + " - Deleted");
			}
		}

		public void StartDetection()
		{
			Console.WriteLine(">>> Detection process started. Press 'q' to exit.");

			// Create a timer that will run the detection logic every 5 seconds
			detectionTimer = new Timer(OnTimerElapsed, null, 0, 5000);

			while (true)
			{
				if (Console.KeyAvailable)
				{
					var key = Console.ReadKey(intercept: true).Key;
					if (key == ConsoleKey.Q)
					{
						// Dispose of the timer and exit when 'q' is pressed
						stopEvent.Set();
						break;
					}
				}
			}
			stopEvent.WaitOne();
		}

		private void OnTimerElapsed(object state)
		{
			List<string> previousFiles = new List<string>();
			snapshotFileManager.ExtractSavedFiles(previousFiles);
			PrintStatus(snapshotTime, previousFiles);
			snapshotTime = commit.UpdateSnaphotTime();

			//Console.WriteLine(">>> Running detection process at " + DateTime.Now);

			if (stopEvent.WaitOne(0))
			{
				detectionTimer.Dispose();
				stopEvent.Set(); // Set the event to allow the program to exit
			}
		}
	}
}
