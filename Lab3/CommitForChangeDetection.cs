using System;

namespace Lab2
{
	public class CommitForChangeDetection : CommitAction
	{
		// overriding
		new public DateTime UpdateSnaphotTime()
		{
			DateTime snapshotTime = DateTime.Now;
			return snapshotTime;
		}
	}
}
