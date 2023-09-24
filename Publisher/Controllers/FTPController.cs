using Publisher.Models;
using System.Collections.Generic;
using System.Threading;

namespace Publisher.Controllers
{
	public class FTPController
	{
		private static readonly FTPController instance = new FTPController();
		public static FTPController Instance { get { return instance; } }

		private Thread uploadThread;

		public const string PatchFileName = @"PList.gz";
		public const string TempDownloadDirectory = "In";
		public const string TempUploadDirectory = "Out";
		public string[] ExcludeList = new string[] { "Thumbs.db" };
		public Queue<FileInformation> UploadList;
		public List<FileInformation> OldList, NewList;

		public void Initialize()
		{
			MessageQueue.Instance.Enqueue("FTP Thread 초기화");

			uploadThread = new Thread(new ThreadStart(Process));
			uploadThread.IsBackground = true;
			uploadThread.Start();
		}

		private void Process()
		{

		}
	}
}
