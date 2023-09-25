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
    }
}
