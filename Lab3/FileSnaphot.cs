using System;
namespace Lab2
{
    public class FileSnapshot
    {
        private DateTime LastModified { get; set; }

		public static implicit operator FileSnapshot(DateTime v)
		{
			throw new NotImplementedException();
		}
	}
}