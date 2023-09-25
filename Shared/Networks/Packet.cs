using System;
using System.Collections.Generic;
using System.IO;
using S = ServerPackets;
using C = ClientPackets;

namespace Shared.Networks
{
    public abstract class Packet
    {
        public static bool IsServer;
        public abstract short Index { get; }

        protected abstract void ReadPacket(BinaryReader reader);
        protected abstract void WritePacket(BinaryWriter writer);

        public static Packet ReceivePacket(byte[] rawBytes, out byte[] extra)
        {
            extra = rawBytes;

            Packet p;

            // Packet Size -> 2Bytes
            // Packet ID -> 2Bytes
            if (rawBytes.Length < 4) return null;

            int length = (rawBytes[1] << 8) + rawBytes[0];

            if (length > rawBytes.Length || length < 2) return null;

            using (MemoryStream stream = new MemoryStream(rawBytes, 2, length - 2))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                try
                {
                    short id = reader.ReadInt16();

                    p = IsServer ? GetClientPacket(id) : GetServerPacket(id);
                    if (p == null) return null;

                    p.ReadPacket(reader);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw new InvalidDataException();
                }
            }

            extra = new byte[rawBytes.Length - length];
            Buffer.BlockCopy(rawBytes, length, extra, 0, rawBytes.Length - length);

            return p;
        }

        public IEnumerable<byte> GetPacketBytes()
        {
            if (Index < 0) return new byte[0];

            byte[] data;

            using (MemoryStream stream = new MemoryStream())
            {
                stream.SetLength(2);
                stream.Seek(2, SeekOrigin.Begin);
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(Index);
                    WritePacket(writer);
                    stream.Seek(0, SeekOrigin.Begin);
                    writer.Write((short)stream.Length);
                    stream.Seek(0, SeekOrigin.Begin);

                    data = new byte[stream.Length];
                    stream.Read(data, 0, data.Length);
                }
            }

            return data;
        }

        private static Packet GetClientPacket(short index)
        {
            switch (index)
            {
                case (short)ClientPacketIds.ClientVersion:
                    return new C.ClientVersion();
                case (short)ClientPacketIds.Disconnect:
                    return new C.Disconnect();
                case (short)ClientPacketIds.KeepAlive:
                    return new C.KeepAlive();                
                default:
                    return null;
            }
        }

        public static Packet GetServerPacket(short index)
        {
            switch (index)
            {
                case (short)ServerPacketIds.Connected:
                    return new S.Connected();
                case (short)ServerPacketIds.ClientVersion:
                    return new S.ClientVersion();
                case (short)ServerPacketIds.Disconnect:
                    return new S.Disconnect();
                case (short)ServerPacketIds.KeepAlive:
                    return new S.KeepAlive();
                default:
                    return null;
            }
        }
    }
}
