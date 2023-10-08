namespace Shared.Networks
{
    public enum ServerPacketIds : short
    {
        Connected,
        Disconnect,
        ClientVersion,
        KeepAlive,
        SignUpCheckResult
    }

    public enum ClientPacketIds : short
    {
        ClientVersion,
        Disconnect,
        KeepAlive,
        SignUpCheck
    }
}
