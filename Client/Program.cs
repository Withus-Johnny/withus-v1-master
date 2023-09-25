using Client.Features.Logger;
using Client.Forms;
using System;
using System.Windows.Forms;

namespace Client
{
    internal static class Program
    {
        public static CMain CMain;
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.Instance.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(CMain = new CMain());
        }
    }
}
