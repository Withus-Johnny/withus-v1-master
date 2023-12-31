﻿using Publisher.Forms;
using System;
using System.Windows.Forms;

namespace Publisher
{
    internal static class Program
    {
        public static PMain PMain;
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
			MessageQueue.Instance.Enqueue("설정을 불러옵니다.");
			Settings.Load();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(PMain = new PMain());
        }
    }
}
