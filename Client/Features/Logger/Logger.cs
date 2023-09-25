using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Client.Features.Logger
{
    public class Logger : ILogger
    {
        private Thread _loggerThread;

        private static readonly Logger _instance = new Logger();
        public static Logger Instance { get { return _instance; } }

        private ConcurrentQueue<LogInfo> LogMessage = new ConcurrentQueue<LogInfo>();

        public void Initialize()
        {
            if (_loggerThread != null)
            {
                try
                {
                    _loggerThread.Abort();
                }
                catch { }
                finally
                {
                    _loggerThread = null;
                }
            }

            _loggerThread = new Thread(new ThreadStart(Process));
            _loggerThread.IsBackground = true;
            _loggerThread.Start();
        }

        private void Process()
        {
            int dqErrorCount = 0;
            while (_loggerThread.IsAlive)
            {
                if (LogMessage.IsEmpty)
                {
                    Thread.Sleep(50);
                    continue;
                }

                if (!LogMessage.TryDequeue(out LogInfo dqInfo))
                {
                    dqErrorCount++;
                    if (dqErrorCount >= 10)
                    {
                        _loggerThread.Abort();
                        return;
                    }
                    continue;
                }

                dqErrorCount = 0;
                string logPath = $"{Environment.CurrentDirectory}\\LOG\\";
                string logFileName = dqInfo.Created_DateTime.ToString("yyyyMMdd") + ".txt";

                try
                {
                    Directory.CreateDirectory(logPath);
                    string logFilePath = Path.Combine(logPath, logFileName);

                    int lineWidth = dqInfo.Summary.Length;
                    string horizontalLine = new string('-', lineWidth + 10);

                    using (StreamWriter writer = new StreamWriter(logFilePath, true))
                    {
                        writer.WriteLine(horizontalLine);
                        writer.WriteLine($"시각 : {dqInfo.Created_DateTime:yyyy.MM.dd HH:mm:ss:fffffff}");
                        switch (dqInfo.LogType)
                        {
                            case LogType.System:
                                writer.WriteLine("타입 : 시스템");
                                break;
                            case LogType.Information:
                                writer.WriteLine("타입 : 정보");
                                break;
                            case LogType.Error:
                                writer.WriteLine("타입 : 에러");
                                writer.WriteLine($"클래스명 : {dqInfo.SourcePath}");
                                writer.WriteLine($"함수명 : {dqInfo.MemberName}");
                                writer.WriteLine($"줄 : {dqInfo.SourceLine}");
                                break;
                        }
                        writer.WriteLine($"요약 : {dqInfo.Summary}");
                        writer.WriteLine($"설명 : {dqInfo.Description}");
                        writer.WriteLine(horizontalLine);
                    }
                }
                catch { };
            }
        }

        public void Enqueue(LogType type, string summary, string description,
                            [CallerMemberName] string memberName = "",
                            [CallerFilePath] string sourceFilePath = "",
                            [CallerLineNumber] int sourceLineNumber = 0)
        {
            LogInfo info = new LogInfo();
            info.LogType = type;
            info.Created_DateTime = DateTime.Now;
            info.Summary = summary;
            info.Description = description;
            info.MemberName = memberName;
            if (!string.IsNullOrEmpty(sourceFilePath))
            {
                sourceFilePath = sourceFilePath.Split('\\').Last();
            }
            info.SourcePath = sourceFilePath;
            info.SourceLine = sourceLineNumber;
            LogMessage.Enqueue(info);
        }
    }
}
