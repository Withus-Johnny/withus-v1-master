using Publisher.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using WinSCP;

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
			GetOldFileList();
			GetNewFileList();
			PrepareFileUploads();
			BeginUpload();
		}

		private void BeginUpload()
		{
			if (UploadList == null)
			{
				return;
			}

			Program.PMain.UpdateProgressBar1(0);
			Program.PMain.UpdateProgressBar2(0);
			Program.PMain.statusLabel_All.Text = UploadList.Count.ToString();
			int uploadCount = UploadList.Count;

			while (UploadList.Count > 0)
			{
				FileInformation info = UploadList.Dequeue();

				CreateTempUploadFiles(info, File.ReadAllBytes(Settings.TargetPath + (info.FileName)));
			}

			CleanUp();
			CreateTempUploadFiles(new FileInformation { FileName = PatchFileName }, CreateNewList());

			UploadFiles(++uploadCount);

			UploadList = null;
		}

		private byte[] CreateNewList()
		{
			using (MemoryStream stream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter(stream))
				{
					writer.Write(NewList.Count);
					for (int i = 0; i < NewList.Count; i++)
					{
						NewList[i].Save(writer);
					}

					return stream.ToArray();
				}
			}
		}

		private void CompleteUpload()
		{
			string complated = "완료";
			Program.PMain.FileNameLabelText = complated;
			Program.PMain.SpeedLabelText = complated;
			Program.PMain.RemainingCount = "0";
			MessageQueue.Instance.Enqueue("배포가 완료되었습니다.");
		}

		private string FormatSpeed(double speed)
		{
			string[] units = { "B/s", "KB/s", "MB/s", "GB/s", "TB/s" };

			int index = 0;
			while (speed >= 1024 && index < units.Length - 1)
			{
				speed /= 1024;
				index++;
			}

			return $"{speed:0.##} {units[index]}";
		}

		private void UploadFiles(int uploadCount = 0)
		{
			var rootPath = (new Uri(Settings.Host)).AbsolutePath;

			MessageQueue.Instance.Enqueue("세션을 초기화 합니다.");
			using (Session session = new Session())
			{
				session.FileTransferProgress += (o, e) =>
				{
					int value = (int)(e.OverallProgress * 100);
					Program.PMain.UpdateProgressBar1(value);

					int value2 = (int)(e.FileProgress * 100);
					Program.PMain.UpdateProgressBar2(value2);

					Program.PMain.FileNameLabelText = e.FileName.TrimStart(TempUploadDirectory.ToCharArray()).TrimStart('\\');

					Program.PMain.SpeedLabelText = FormatSpeed((double)e.CPS);
					Program.PMain.RemainingCount = uploadCount.ToString();
					MessageQueue.Instance.Enqueue($"{e.FileName.Split('\\').Last()} 업로드 중 | {value2}% ({Program.PMain.SpeedLabelText})");
				};

				session.FileTransferred += (o, e) =>
				{
					MessageQueue.Instance.Enqueue($"{e.Touch.FileName.Replace("/", "")} 업로드 완료.");
					uploadCount--;

					if (uploadCount <= 0)
					{
						uploadCount = 0;
						CompleteUpload();
					}
				};

				OpenSession(session);

				TransferOptions transferOptions = new TransferOptions
				{
					TransferMode = TransferMode.Binary,
					OverwriteMode = OverwriteMode.Overwrite
				};

				if (!session.FileExists(rootPath))
				{
					MessageQueue.Instance.Enqueue("루트 디렉토리를 생성합니다.");
					session.CreateDirectory(rootPath);
				}

				var result = session.PutFilesToDirectory(TempUploadDirectory, rootPath, options: transferOptions);
				result.Check();

				MessageQueue.Instance.Enqueue("임시 업로드 디렉토리를 삭제합니다.");
				DeleteDirectory(TempUploadDirectory);
			}
		}

		private bool NeedFile(string fileName)
		{
			for (int i = 0; i < NewList.Count; i++)
			{
				if (fileName.EndsWith(NewList[i].FileName) && !InExcludeList(NewList[i].FileName))
				{
					return true;
				}
			}
			return false;
		}

		private void CleanUp()
		{
			var rootPath = (new Uri(Settings.Host)).AbsolutePath;

			using (Session session = new Session())
			{
				OpenSession(session);

				for (int i = 0; i < OldList.Count; i++)
				{
					if (NeedFile(OldList[i].FileName)) continue;

					var compressed = OldList[i].Length != OldList[i].Compressed;

					try
					{
						var filename = OldList[i].FileName + (compressed ? ".gz" : "");

						var filePath = Path.Combine(rootPath, filename).Replace(@"\", "/");

						if (session.FileExists(filePath))
						{
							MessageQueue.Instance.Enqueue($"저장소 파일 삭제 - {filename}");
							session.RemoveFile(filePath);
						}
					}
					catch
					{

					}
				}
			}
		}

		private void CreateTempUploadFiles(FileInformation info, byte[] raw)
		{
			string fileName = info.FileName.Replace(@"\", "/");

			byte[] data = (!false || fileName == "PList.gz") ? raw : Compress(raw);
			info.Compressed = data.Length;

			if (fileName != "PList.gz" && false)
			{
				fileName += ".gz";
			}

			var sourceDir = Path.GetDirectoryName(fileName);
			var tempSourceDir = Path.Combine(TempUploadDirectory, sourceDir);

			var tempFilePath = Path.Combine(TempUploadDirectory, fileName).Replace(@"\", "/");

			if (!Directory.Exists(tempSourceDir))
			{
				Directory.CreateDirectory(tempSourceDir);
			}

			File.WriteAllBytes(tempFilePath, data);
			File.SetLastWriteTime(tempFilePath, info.Creation);
		}

		private byte[] Compress(byte[] raw)
		{
			using (MemoryStream mStream = new MemoryStream())
			{
				using (GZipStream gStream = new GZipStream(mStream, CompressionMode.Compress, true))
					gStream.Write(raw, 0, raw.Length);
				return mStream.ToArray();
			}
		}

		private void PrepareFileUploads()
		{
			if (UploadList == null)
				UploadList = new Queue<FileInformation>();

			for (int i = 0; i < NewList.Count; i++)
			{
				FileInformation info = NewList[i];

				if (InExcludeList(info.FileName)) continue;

				if (NeedUpdate(info))
				{
					UploadList.Enqueue(info);
				}
				else
				{
					for (int j = 0; j < OldList.Count; j++)
					{
						if (OldList[j].FileName != info.FileName) continue;
						NewList[i] = OldList[j];
						break;
					}
				}
			}
		}

		private bool NeedUpdate(FileInformation info)
		{
			for (int i = 0; i < OldList.Count; i++)
			{
				FileInformation old = OldList[i];
				if (old.FileName != info.FileName) continue;

				if (old.Length != info.Length) return true;
				if (old.Creation != info.Creation) return true;

				return false;
			}

			return true;
		}

		private bool InExcludeList(string fileName)
		{
			foreach (var item in ExcludeList)
			{
				if (fileName.EndsWith(item))
				{
					return true;
				}
			}

			return false;
		}

		private void GetNewFileList()
		{
			MessageQueue.Instance.Enqueue("배포 파일을 읽고 있습니다.");

			NewList = new List<FileInformation>();

			string[] files = Directory.GetFiles(Settings.TargetPath, "*.*", SearchOption.AllDirectories);


			for (int i = 0; i < files.Length; i++)
			{
				var fi = GetFileInformation(files[i]);
				NewList.Add(fi);
			}
		}

		private FileInformation GetFileInformation(string fileName)
		{
			if (!File.Exists(fileName)) return null;

			FileInfo info = new FileInfo(fileName);
			FileInformation file = new FileInformation
			{
				FileName = fileName.Remove(0, Settings.TargetPath.Length).TrimStart('\\'),
				Length = (int)info.Length,
				Creation = info.LastWriteTime
			};
			MessageQueue.Instance.Enqueue($"> FileName = {file.FileName}, Length = {file.Length}, Creation = {file.Creation}");
			return file;
		}

		private void GetOldFileList()
		{
			UploadList = new Queue<FileInformation>();
			OldList = new List<FileInformation>();

			MessageQueue.Instance.Enqueue($"{PatchFileName} 다운로드를 시작 합니다.");
			byte[] data = DownloadFile(PatchFileName);

			if (data != null)
			{
				using (MemoryStream stream = new MemoryStream(data))
				{
					using (BinaryReader reader = new BinaryReader(stream))
					{
						int count = reader.ReadInt32();
						for (int i = 0; i < count; i++)
						{
							FileInformation temp = new FileInformation(reader);
							OldList.Add(temp);
						}
					}
				}

				MessageQueue.Instance.Enqueue($"저장소의 파일 정보들을 불러왔습니다.");
			}
			else
			{
				MessageQueue.Instance.Enqueue($"{PatchFileName}을 찾을 수 없습니다.");
			}
		}

		private byte[] DownloadFile(string fileName)
		{
			using (Session session = new Session())
			{
				OpenSession(session);

				try
				{
					if (!Directory.Exists(TempDownloadDirectory))
					{
						Directory.CreateDirectory(TempDownloadDirectory);
					}

					TransferOptions transferOptions = new TransferOptions
					{
						TransferMode = TransferMode.Binary,
						OverwriteMode = OverwriteMode.Overwrite
					};

					var rootPath = (new Uri(Settings.Host)).AbsolutePath;

					var result = session.GetFiles(Path.Combine(rootPath, fileName), Path.Combine(TempDownloadDirectory, fileName), options: transferOptions);
					result.Check();

					MemoryStream ms = new MemoryStream();
					using (FileStream fs = new FileStream(Path.Combine(TempDownloadDirectory, fileName), FileMode.Open, FileAccess.Read))
						fs.CopyTo(ms);

					DeleteDirectory(TempDownloadDirectory);

					return ms.ToArray();
				}
				catch
				{
					DeleteDirectory(TempDownloadDirectory);
					return null;
				}
			}
		}

		private void OpenSession(Session session)
		{
			if (session.Opened)
			{
				MessageQueue.Instance.Enqueue("이미 세션이 열려있습니다.");
				return;
			}

			Uri uri = null;

			if (!string.IsNullOrEmpty(Settings.Host))
			{
				uri = new Uri(Settings.Host);
			}

			if (!Protocol.TryParse(Settings.Protocol, true, out Protocol protocol))
			{
				protocol = Protocol.Ftp;
			}

			SessionOptions sessionOptions = new SessionOptions
			{
				Protocol = protocol,
				HostName = uri.Host,
				UserName = Settings.UserName,
				Password = Settings.UserPassword
			};

			if (sessionOptions.Protocol == Protocol.Sftp)
			{
				var fingerprint = session.ScanFingerprint(sessionOptions, "SHA-256");
				sessionOptions.SshHostKeyFingerprint = fingerprint;
			}

			session.Open(sessionOptions);
		}

		private void DeleteDirectory(string target_dir)
		{
			if (!Directory.Exists(target_dir)) return;

			string[] files = Directory.GetFiles(target_dir);
			string[] dirs = Directory.GetDirectories(target_dir);

			foreach (string file in files)
			{
				File.SetAttributes(file, FileAttributes.Normal);
				File.Delete(file);
			}

			foreach (string dir in dirs)
			{
				DeleteDirectory(dir);
			}

			Directory.Delete(target_dir, false);
		}
	}
}
