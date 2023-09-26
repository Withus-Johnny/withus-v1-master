using Client.Features.Logger;
using Client.Networks;
using Shared.Networks;
using System;
using System.Diagnostics;
using System.Threading;
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


        public void InitializeNetwork()
        {
            Program.Logger.Enqueue(LogType.System, "네트워크", "네트워크 초기화");
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
                    Program.Logger.Enqueue(LogType.System, "네트워크", "서버 연결 됨");
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
                    Program.Logger.Enqueue(LogType.System, "버전체크 실패", "클라이언트 버전이 불일치");
                    Network.Disconnect("클라이언트 버전이 불일치합니다.");
                    break;
                case 1:
                    Program.Logger.Enqueue(LogType.System, "버전체크 성공", "로그인폼 활성화");
                    Program.LoginForm.FormVisible = true;
                    break;
            }
        }

        private void KeepAlive(S.KeepAlive p)
        {
            if (p.Time == 0) return;
            Network.PingTime = (Time - p.Time);
        }
    }
}
