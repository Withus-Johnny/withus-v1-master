using MasterServer.Environments;
using Shared.Networks;
using System.Runtime.InteropServices;

namespace MasterServer
{
    public class Program
    {
        #region TopMost
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd,
                                    IntPtr hWndInsertAfter,
                                    int X,
                                    int Y,
                                    int cx,
                                    int cy,
                                    uint uFlags);
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        const uint SWP_NOSIZE = 0x0001, SWP_NOMOVE = 0x0002, SWP_SHOWWINDOW = 0x0040;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        #endregion

        public static Envir Envir { get; private set; }
        static void Main(string[] args)
        {
            // TopMost
#if DEBUG
            IntPtr handle = GetConsoleWindow();
            SetWindowPos(handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
#endif

            Settings.LoadClientVersion();

            Packet.IsServer = true;
            Envir = new Envir();
            Envir.Start();

            Console.WriteLine("WITHUS SERVER END");
            Console.ReadKey();
        }
    }
}