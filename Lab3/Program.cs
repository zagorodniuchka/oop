using System.Threading;
using Lab2;


var consoleMenu = new ConsoleMenu();
var menuThread = new Thread(new ThreadStart(consoleMenu.ConsoleOperations));
menuThread.Start();

var changeDetection = new FileChangeDetection();
Thread detectionThred = new Thread(new ThreadStart(changeDetection.StartDetection));
detectionThred.Start();
detectionThred.Join(); 

menuThread.Join();
