using System.Runtime.CompilerServices;

namespace Client.Features.Logger
{
    public interface ILogger
    {
        void Initialize();
        void Enqueue(LogType type, string summary, string description,
                            [CallerMemberName] string memberName = "",
                            [CallerFilePath] string sourceFilePath = "",
                            [CallerLineNumber] int sourceLineNumber = 0);
    }
}
