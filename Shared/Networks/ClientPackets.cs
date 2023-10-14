using Shared.Networks;
using System.IO;

namespace ClientPackets
{
    public sealed class ClientVersion : Packet
    {
        public override short Index
        {
            get { return (short)ClientPacketIds.ClientVersion; }
        }

        public byte[] VersionHash;

        protected override void ReadPacket(BinaryReader reader)
        {
            VersionHash = reader.ReadBytes(reader.ReadInt32());
        }
        protected override void WritePacket(BinaryWriter writer)
        {
            writer.Write(VersionHash.Length);
            writer.Write(VersionHash);
        }
    }

    public sealed class Disconnect : Packet
    {
        public override short Index
        {
            get { return (short)ClientPacketIds.Disconnect; }
        }
        protected override void ReadPacket(BinaryReader reader)
        {
        }
        protected override void WritePacket(BinaryWriter writer)
        {
        }
    }

    public sealed class KeepAlive : Packet
    {
        public override short Index
        {
            get { return (short)ClientPacketIds.KeepAlive; }
        }
        public long Time;
        protected override void ReadPacket(BinaryReader reader)
        {
            Time = reader.ReadInt64();
        }
        protected override void WritePacket(BinaryWriter writer)
        {
            writer.Write(Time);
        }
    }

    public sealed class SignUpCheck : Packet
    {
        public override short Index
        {
            get { return (short)ClientPacketIds.SignUpCheck; }
        }
        protected override void ReadPacket(BinaryReader reader)
        {
        }
        protected override void WritePacket(BinaryWriter writer)
        {
        }
    }

    public sealed class SignUp : Packet
    {
        public override short Index
        {
            get { return (short)ClientPacketIds.SignUp; }
        }

        public string UserEmail;
        public string HashedPassword;
        public string UserName;
        public string UserPhone;

        protected override void ReadPacket(BinaryReader reader)
        {
            UserEmail = reader.ReadString();
            HashedPassword = reader.ReadString();
            UserName = reader.ReadString();
            UserPhone = reader.ReadString();
        }
        protected override void WritePacket(BinaryWriter writer)
        {
            writer.Write(UserEmail);
            writer.Write(HashedPassword);
            writer.Write(UserName);
            writer.Write(UserPhone);
        }
    }
}
