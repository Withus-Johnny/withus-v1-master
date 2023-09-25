using Client.Controllers;
using Shared.Networks;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;
using C = ClientPackets;

namespace Client.Networks
{
    public static class Network
    {
        private static TcpClient _client;
        public static bool Connected;
        public static long TimeOutTime, TimeConnected, RetryTime = SystemController.Time + 3000;

        private static ConcurrentQueue<Packet> _receiveList;
        private static ConcurrentQueue<Packet> _sendList;

        static byte[] _rawData = new byte[0];
        static readonly byte[] _rawBytes = new byte[8 * 1024];

        public static long PingTime;

        public static void Connect()
        {
            try
            {
                _client = new TcpClient { NoDelay = true };
                _client.BeginConnect("127.0.0.1", 7777, Connection, null);
            }
            catch
            {
                Disconnect("서버 연결에 실패했습니다.");
            }
        }

        private static void Connection(IAsyncResult result)
        {
            if (_client == null) return;

            try
            {
                _client.EndConnect(result);
                _receiveList = new ConcurrentQueue<Packet>();
                _sendList = new ConcurrentQueue<Packet>();
                _rawData = new byte[0];

                TimeOutTime = SystemController.Time + 3000;
                TimeConnected = SystemController.Time;

                BeginReceive();
            }
            catch
            {
                Disconnect("서버에 연결 할 수 없습니다.");
            }
        }

        private static void BeginReceive()
        {
            if (_client == null) return;
            if (!_client.Connected) return;
            if (_client.Client == null) return;

            try
            {
                _client.Client.BeginReceive(_rawBytes, 0, _rawBytes.Length, SocketFlags.None, ReceiveData, _rawBytes);
            }
            catch
            {
                Disconnect("응답 처리 중 오류가 발생 했습니다.");
            }
        }

        private static void ReceiveData(IAsyncResult result)
        {
            if (_client == null) return;
            if (_client.Client == null) return;
            if (!_client.Connected) return;

            int dataRead;

            try
            {
                dataRead = _client.Client.EndReceive(result);
            }
            catch { return; };

            if (dataRead == 0)
            {
                Disconnect("서버와의 연결이 해제 되었습니다.");
            }

            byte[] rawBytes = result.AsyncState as byte[];

            byte[] temp = _rawData;
            _rawData = new byte[dataRead + temp.Length];
            Buffer.BlockCopy(temp, 0, _rawData, 0, temp.Length);
            Buffer.BlockCopy(rawBytes, 0, _rawData, temp.Length, dataRead);

            Packet p;
            List<byte> data = new List<byte>();

            while ((p = Packet.ReceivePacket(_rawData, out _rawData)) != null)
            {
                data.AddRange(p.GetPacketBytes());
                _receiveList.Enqueue(p);
            }

            SystemController.BytesReceived += data.Count;

            BeginReceive();
        }

        public static void Disconnect(string msg)
        {
            if (_client == null) return;

            SystemController.Instance.isRunning = false;

            _client?.Close();

            TimeConnected = 0;
            Connected = false;
            _sendList = null;
            _client = null;

            _receiveList = null;

            MessageBox.Show(msg, "시스템");
            Application.Exit();
        }

        public static void Process()
        {
            try
            {
                if (_client == null)
                {
                    if (Connected)
                    {
                        while (_receiveList != null && !_receiveList.IsEmpty)
                        {
                            if (!_receiveList.TryDequeue(out Packet p) || p == null) continue;
                            if (!(p is ServerPackets.Disconnect) && !(p is ServerPackets.ClientVersion)) continue;

                            SystemController.Instance.ProcessPacket(p);
                            _receiveList = null;
                            return;
                        }

                        Disconnect("연결이 해제되었습니다. Error:154");
                    }
                    return;
                }

                if (_client.Client == null)
                {
                    Disconnect("연결이 해제되었습니다. Error:161");
                }

                if (Connected && !_client.Client.Connected)
                {
                    Disconnect("서버와 연결이 해제되었습니다.");
                }

                while (_receiveList != null && !_receiveList.IsEmpty)
                {
                    if (!_receiveList.TryDequeue(out Packet p) || p == null) continue;
                    SystemController.Instance.ProcessPacket(p);
                }


                if (SystemController.Time > TimeOutTime && _sendList != null && _sendList.IsEmpty)
                {
                    Enqueue(new C.KeepAlive() { Time = SystemController.Time });
                }

                if (_sendList == null || _sendList.IsEmpty) return;

                TimeOutTime = SystemController.Time + 2000;

                List<byte> data = new List<byte>();
                while (!_sendList.IsEmpty)
                {
                    if (!_sendList.TryDequeue(out Packet p)) continue;
                    data.AddRange(p.GetPacketBytes());
                }

                SystemController.BytesSent += data.Count;

                BeginSend(data);
            }
            catch (Exception e)
            {
                Disconnect($"연결이 해제되었습니다. Error:234\n{e.Message}");
            };
        }

        private static void BeginSend(List<byte> data)
        {
            if (_client == null) return;
            if (_client.Client == null) return;
            if (!_client.Connected) return;
            if (data == null) return;
            if (data.Count == 0) return;

            try
            {
                _client.Client.BeginSend(data.ToArray(), 0, data.Count, SocketFlags.None, SendData, null);
            }
            catch
            {
                Disconnect("데이터를 보내는 중 오류가 발생 했습니다.");
            }
        }
        private static void SendData(IAsyncResult result)
        {
            if (_client.Client == null) return;

            try
            {
                _client.Client.EndSend(result);
            }
            catch
            { }
        }

        public static void Enqueue(Packet p)
        {
            if (_sendList != null && p != null)
            {
                _sendList.Enqueue(p);
            }
        }
    }
}
