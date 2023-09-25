namespace Shared.Networks
{
    public enum DisconnectReason : byte
    {
        TimeOut,
        ClientShutDown,
        ClientExit,
        Maintainance
    }
}
