using System;
namespace Lab2
{
    public class CommitAction
    {
        protected  DateTime snapshotTime = DateTime.Now;
       
		public DateTime UpdateSnaphotTime() 
        {
			DateTime snapshotTime = DateTime.Now;
            Console.WriteLine("Snapshot time updated to: " + snapshotTime);
            return snapshotTime;
        }
    }
}
