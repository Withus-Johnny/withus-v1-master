namespace Publisher
{
    public class Settings
    {
        private static InIReader Reader = new InIReader(@".\Config.ini");

        public static string TargetPath = @"D:\Debug\Client";
        public static string Host = "127.0.0.1";
        public static string UserName = "InputUserName";
        public static string UserPassword = "InputPassword";
        public static readonly string Protocol = "FTP";

        public static void Load()
        {
            TargetPath = Reader.ReadString("TARGET", "Path", TargetPath);
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
    }
}
