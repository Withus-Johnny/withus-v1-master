using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Publisher
{
	public static class Validator
	{
		public static bool IsValid(string path)
		{
			MessageQueue.Instance.Enqueue("설정 유효성 검사를 시작 합니다.");
			if (string.IsNullOrEmpty(path))
			{
				MessageQueue.Instance.Enqueue("업로드 대상 디렉토리가 지정되지 않았습니다.");
				return false;
			}

			try
			{
				Program.PMain.menuItem_Publishing.Enabled = false;
				Program.PMain.statusLabel_ComplatedCount.Text = "0";
				Program.PMain.statusLabel_All.Text = "0";

				DirectoryInfo di = new DirectoryInfo(path);
				if (di.Exists)
				{
					List<FileInfo> fileInfoList = di.GetFiles("*.*", SearchOption.AllDirectories).ToList();
					if (fileInfoList.Count > 0)
					{
						Program.PMain.menuItem_Publishing.Enabled = true;
						Program.PMain.statusLabel_All.Text = fileInfoList.Count.ToString();
						MessageQueue.Instance.Enqueue("유효성 검사 성공");
						return true;
					}
				}

				di.Create();
				MessageQueue.Instance.Enqueue("유효성 검사 실패");
				return false;
			}
			catch (Exception e)
			{
				MessageQueue.Instance.Enqueue($"유효성 검사 실패\n{e.Message}");
				return false;
			}
		}
	}
}
