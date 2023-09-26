using System.Security.Cryptography;

namespace MasterServer.Environments
{
    public static class Settings
    {
        public const int Day = 24 * Hour, Hour = 60 * Minute, Minute = 60 * Second, Second = 1000;

        // 네트워크
        public static string IPAddress = "127.0.0.1";

        public static ushort Port = 7777,
                             TimeOut = 10 * Second,
                             MaxUser = 100,
                             MaxIP = 1,
                             MaxPacket = 50;

        public static string APIServerBaseAddress = "http://127.0.0.1:5000/api/v1/";

        // 일반
        public static string VersionPath = Path.Combine(".", "Client.exe");

#if DEBUG
        public static bool VersionCheck = false;
#else
        public static bool VersionCheck = true;
#endif

        public static List<byte[]> VersionHashes;

        public static void LoadClientVersion()
        {
            try
            {
                VersionHashes = new List<byte[]>();

                var paths = VersionPath.Split(',');

                foreach (var path in paths)
                {
                    if (File.Exists(path))
                        using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                        using (MD5 md5 = MD5.Create())
                            VersionHashes.Add(md5.ComputeHash(stream));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
