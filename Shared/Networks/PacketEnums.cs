namespace Shared.Networks
{
    public enum ServerPacketIds : short
    {
        Connected,
        Disconnect,
        ClientVersion,
        KeepAlive,
        // 회원가입 가입 여부 결과
        SignUpCheckResult
    }

    public enum ClientPacketIds : short
    {
        ClientVersion,
        Disconnect,
        KeepAlive,
        // 회원가입 가입 여부
        SignUpCheck,
        SignUp
    }
}
