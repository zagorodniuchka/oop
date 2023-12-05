using Lab2;
using System;

namespace Lab2
{
	public class ConsoleMenu
	{
		public void ConsoleOperations()
		{
			string option = "";
			DateTime snapshotTime = DateTime.Now;
			CommitAction commitAction = new CommitAction();
			SnapshotStorageFileManager snapshotStorage = new SnapshotStorageFileManager();
			InfoAllFiles allFilesInfo = new InfoAllFiles();
			InfoImageFiles infoImageFiles = new InfoImageFiles();
			InfoTextFiles infoTextFiles = new InfoTextFiles();
			InfoProgramFiles infoProgramFiles = new InfoProgramFiles();
			StatusAction statusAction = new StatusAction();
			SnapshotStorageFileManager snapshotFileManager = new SnapshotStorageFileManager();

			Console.WriteLine("Available options: ");
			Console.WriteLine("1. commit");
			Console.WriteLine("2. info <filename> (allfiles, image, text, program)");
			Console.WriteLine("3. status");
			Console.WriteLine("4. q - quit");
			while (option != "q")
			{
				
				Console.Write("\n>>> ");
				option = Console.ReadLine();
				string[] splitOption = option.Split(' ');
				switch (splitOption[0])
				{
					case "commit":
						snapshotTime = commitAction.UpdateSnaphotTime();
						snapshotStorage.StoreSnapshot(snapshotTime);
						break;
					case "info":
						string[] getExtension = splitOption[1].Split('.');
						switch (getExtension.Length)
						{
							case 1:
								//info allfiles
								allFilesInfo.PrintInfoFiles();
								break;
							case 2:
								switch (getExtension[1])
								{
									case "png":
										//info image file.png  +++
										infoImageFiles.PrintImageSize(splitOption[1]);
										break;
									case "txt":
										//info text file.txt
										infoTextFiles.GetCountLines(splitOption[1]);
										infoTextFiles.GetCountWords(splitOption[1]);
										infoTextFiles.GetCountCharacter(splitOption[1]);
										infoTextFiles.PrintFileInfo(splitOption[1]);
										break;

									//info programFiles
									case "cs":
										infoProgramFiles.GetCountLines(splitOption[1]);
										infoProgramFiles.GetCountClasses(splitOption[1]);
										infoProgramFiles.GetCountMethodsJava(splitOption[1]);
										infoProgramFiles.PrintProgramFileInfo(splitOption[1]);
										break;
									case "py":
										infoProgramFiles.GetCountLines(splitOption[1]);
										infoProgramFiles.GetCountClasses(splitOption[1]);
										infoProgramFiles.GetCountMethodsPython(splitOption[1]);
										infoProgramFiles.PrintProgramFileInfo(splitOption[1]);
										break;


								}
								break;
						}
						break;
					case "status":
						snapshotFileManager.ExtractLastSnapshot(snapshotTime);
						var previousFiles = new List<string>();
						snapshotFileManager.ExtractSavedFiles(previousFiles);
						statusAction.PrintStatus(snapshotTime, previousFiles);
						break;
					case "q":
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Wrong operation!");
						break;
				}
			}
        }
    }
}

