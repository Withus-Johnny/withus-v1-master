using Client.Features.Logger;
using Client.Networks;
using Shared.Networks;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using C = ClientPackets;
using S = ServerPackets;

namespace Client.Controllers
{
    public class SystemController
    {
        private static readonly SystemController instance = new SystemController();
        public static SystemController Instance { get { return instance; } }

        private Thread networkThread;
        public bool isRunning { get; set; }

        public Stopwatch Timer = Stopwatch.StartNew();
        public DateTime StartTime = DateTime.UtcNow;
        public DateTime Now { get { return StartTime.AddMilliseconds(Time); } }
        public static long Time;

        public static double BytesSent, BytesReceived;

        private ILogger _logger;

        public void InitializeNetwork()
        {
            _logger = Program.Logger;

            networkThread = new Thread(new ThreadStart(Running));
            networkThread.IsBackground = true;
            networkThread.Start();
        }

        private void Running()
        {
            Timer = Stopwatch.StartNew();
            StartTime = DateTime.UtcNow;

            isRunning = true;
            Network.Connect();

            try
            {
                while (isRunning)
                {
                    Time = Timer.ElapsedMilliseconds;
                    Network.Process();
                }

                Time = 0;
                BytesSent = 0;
                BytesReceived = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Stop()
        {
            try
            {
                if (isRunning)
                {
                    Network.Enqueue(new C.Disconnect());
                }

                isRunning = false;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void ProcessPacket(Packet p)
        {
            switch (p.Index)
            {
                case (short)ServerPacketIds.Connected:
                    Network.Connected = true;
                    SendClientVersion();
                    break;
                case (short)ServerPacketIds.KeepAlive:
                    KeepAlive((S.KeepAlive)p);
                    break;
                case (short)ServerPacketIds.ClientVersion:
                    ClientVersion((S.ClientVersion)p);
                    break;
                default:
                    Console.WriteLine($"미개발 : {p.Index}");
                    break;
            }
        }

        private void ClientVersion(S.ClientVersion p)
        {
            switch (p.Result)
            {
                case 0:
                    Network.Disconnect("클라이언트 버전이 불일치합니다.");
                    break;
                case 1:
                    Program.LoginForm.FormVisible = true;
                    break;
            }
        }

        private void SendClientVersion()
        {
            _logger.Enqueue(LogType.System, "버전체크", "버전 체크를 시작 합니다.");
            C.ClientVersion p = new C.ClientVersion();
            try
            {
                byte[] sum;
                using (MD5 md5 = MD5.Create())
                using (FileStream stream = File.OpenRead(Application.ExecutablePath))
                    sum = md5.ComputeHash(stream);

                p.VersionHash = sum;
                _logger.Enqueue(LogType.Information, "클라이언트 버전", string.Join(" ", p.VersionHash));

                _logger.Enqueue(LogType.System, "버전체크", "버전을 전송합니다.");
                Network.Enqueue(p);
            }
            catch (Exception ex)
            {
                _logger.Enqueue(LogType.Error, "버전 체크 오류 발생", ex.Message);
            }
        }

        private void KeepAlive(S.KeepAlive p)
        {
            if (p.Time == 0) return;
            Network.PingTime = (Time - p.Time);
        }
    }
}
