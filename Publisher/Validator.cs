using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        Console.WriteLine("TRUE");
                        Program.PMain.statusLabel_IsValid.Text = "TRUE";
                        return true;
                    }
                }

                di.Create();
                Console.WriteLine("FALSE");
                Program.PMain.statusLabel_IsValid.Text = "FALSE";
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("FALSE");
                Program.PMain.statusLabel_IsValid.Text = "FALSE";
                return false;
            }
        }
    }
}
