using System;
using System.Collections.Concurrent;

namespace Publisher
{
	public class MessageQueue
	{
		private static readonly MessageQueue instance = new MessageQueue();
		public static MessageQueue Instance { get { return instance; } }

		private ConcurrentQueue<string> Message = new ConcurrentQueue<string>();

		public void Enqueue(string message)
		{
			this.Message.Enqueue(string.Format("[{0}]: {1}" + Environment.NewLine, DateTime.Now, message));
		}

		public bool IsDataEmpty()
		{
			return this.Message.IsEmpty;
		}

		public bool Dequeue(out string message)
		{
			bool isValid = this.Message.TryDequeue(out message);
			return isValid;
		}
	}
}
