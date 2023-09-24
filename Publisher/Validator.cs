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
			if (string.IsNullOrEmpty(path)) return false;

			try
			{
				DirectoryInfo di = new DirectoryInfo(path);
				if (di.Exists)
				{
					List<FileInfo> fileInfoList = di.GetFiles("*.*", SearchOption.AllDirectories).ToList();
					if (fileInfoList.Count > 0)
					{
						Program.PMain.statusLabel_IsValid.Text = "TRUE";
						return true;
					}
				}

				di.Create();
				Program.PMain.statusLabel_IsValid.Text = "FALSE";
				return false;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Program.PMain.statusLabel_IsValid.Text = "FALSE";
				return false;
			}
		}
	}
}
