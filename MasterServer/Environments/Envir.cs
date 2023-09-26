using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using MasterServer.Connections;
using System.Text;

namespace MasterServer.Environments
{
    public class Envir
    {
        public bool Running { get; set; }
        public double RunningTime { get; set; }
        public long Time { get; set; }
        public DateTime Now => _startTime.AddMilliseconds(Time);

        private TcpListener _listener;
        private DateTime _startTime;
        private Stopwatch _stopWatch;

        private int _sessionID;
        public List<WithusClient> WithusClientsList;

        public void Start()
        {
            if (Running) return;

            Running = true;

            _stopWatch = Stopwatch.StartNew();
            Time = _stopWatch.ElapsedMilliseconds;
            _startTime = DateTime.Now;

            WithusClientsList = new List<WithusClient>();

            _listener = new TcpListener(IPAddress.Parse(Settings.IPAddress), Settings.Port);
            _listener.Start();
            _listener.BeginAcceptTcpClient(Connection, null);

            WorkLoop();
        }

        private void Connection(IAsyncResult result)
        {
            if (!Running) return;

            try
            {
                var tempTcpClient = _listener.EndAcceptTcpClient(result);
                var ipAddress = tempTcpClient.Client.RemoteEndPoint.ToString().Split(':')[0];

                int connCount = 0;

                for (int i = 0; i < WithusClientsList.Count; i++)
                {
                    var connection = WithusClientsList[i];

                    if (!connection.Connected || connection.IPAddress != ipAddress)
                        continue;

                    connCount++;
                }

                if (connCount >= Settings.MaxIP)
                {
                    var alreadyConn = WithusClientsList.FirstOrDefault(x => x.IPAddress == ipAddress);
                    if (alreadyConn != null)
                    {
                        Console.WriteLine($"{alreadyConn.IPAddress} 최대 연결 제한으로 기존 연결을 해제합니다.");

                        // 미구현
                    }
                }

                var tempConnection = new WithusClient(++_sessionID, tempTcpClient);
                lock (WithusClientsList)
                {
                    WithusClientsList.Add(tempConnection);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("==============");
                Console.WriteLine(ex.Message);
                Console.WriteLine("==============");
            }
            finally
            {
                if (Running && _listener.Server.IsBound)
                    _listener.BeginAcceptTcpClient(Connection, null);
            }
        }

        private void WorkLoop()
        {
            string title = @"
.----------------------------------.
|__        ___ _   _               |
|\ \      / (_) |_| |__  _   _ ___ |
| \ \ /\ / /| | __| '_ \| | | / __||
|  \ V  V / | | |_| | | | |_| \__ \|
|   \_/\_/  |_|\__|_| |_|\__,_|___/|
'----------------------------------'
";
            var lines = title.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var longestLength = lines.Max(line => line.Length);
            var leadingSpaces = new string(' ', (Console.WindowWidth - longestLength) / 2);
            var centeredText = string.Join(Environment.NewLine,
                lines.Select(line => leadingSpaces + line));

            Console.WriteLine(centeredText);

            while (Running)
            {
                try
                {
                    Time = _stopWatch.ElapsedMilliseconds;
                    RunningTime = (Now - _startTime).TotalSeconds;

                    lock (WithusClientsList)
                    {
                        for (var i = WithusClientsList.Count - 1; i >= 0; i--)
                        {
                            WithusClientsList[i].Process();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("==============");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("==============");
                }
            }
        }
    }
}
