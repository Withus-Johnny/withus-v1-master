using Client.Controllers;
using Client.Features.Logger;
using Client.Forms;
using Shared.Networks;
using System;
using System.Windows.Forms;

namespace Client
{
    internal static class Program
    {
        public static ILogger Logger { get; private set; }

        public static LoginForm LoginForm;
        public static CMain CMain;

        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Packet.IsServer = false;

            InitializeLogger();
            SystemController.Instance.InitializeNetwork();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(LoginForm = new LoginForm());

            SystemController.Instance.Stop();
        }

        private static void InitializeLogger()
        {
            Logger = new Logger();
            Logger.Initialize();
        }
    }
}
