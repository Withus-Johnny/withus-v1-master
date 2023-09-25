using System;

namespace Publisher
{
    public class Settings
    {
        private static InIReader Reader = new InIReader(@".\Config.ini");

        public static string TargetPath = @"C:\Debug\Client\";
        public static string Host = "127.0.0.1";
        public static string UserName = "InputUserName";
        public static string UserPassword = "InputPassword";
        public static readonly string Protocol = "FTP";

        public static void Load()
        {
            TargetPath = Reader.ReadString("TARGET", "Path", TargetPath);

            // 기본 드라이브값으로 처리 할 경우 `접근거부` 등 여러 문제가 발생하며
            // 업로드 대상이 C:\ 전체가 될 수 없기에 아래와 같이 처리 함

            // 업로드 프로세스에서 항상 마지막 역슬레쉬를 요함
            Validator();


            Host = Reader.ReadString("FTP", "Host", Host);
            UserName = Reader.ReadString("FTP", "UserName", UserName);
            UserPassword = Reader.ReadString("FTP", "Password", UserPassword);
        }

        public static void Save()
        {
            Reader.Write("TARGET", "Path", TargetPath);
            Reader.Write("FTP", "Host", Host);
            Reader.Write("FTP", "UserName", UserName);
            Reader.Write("FTP", "Password", UserPassword);
        }

        private static void Validator()
        {
            if (!TargetPath.Equals(@"C:\", StringComparison.OrdinalIgnoreCase))
            {
                if (!TargetPath.EndsWith("\\"))
                {
                    TargetPath += "\\";
                }
            }
            else
            {
                TargetPath = @"C:\Debug\Client\";
            }

            if (Host.Split('.').Length == 3)
            {
                Host = Host.ToUpper().Replace("FTP://", "").Replace("/", "");
                Host = $@"ftp://{Host}/";
            }
        }
    }
}
