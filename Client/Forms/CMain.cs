using Client.Features.Logger;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class CMain : Form
    {
        public CMain()
        {
            InitializeComponent();
        }

        private void CMain_Load(object sender, EventArgs e)
        {
            TestCode();
        }

        private void TestCode()
        {
            ILogger logger = new Logger();
            logger.Initialize();

            logger.Enqueue(LogType.System, "CMain Load Event Call", "클라이언트 메인폼 로드");
            logger.Enqueue(LogType.Error, "CMain Load Event Error", "클라이언트 메인폼 초기화 중 오류 발생");
            Version asbyVersion = Assembly.GetExecutingAssembly().GetName().Version;
            string versionJson = JsonConvert.SerializeObject(asbyVersion, Formatting.Indented);
            logger.Enqueue(LogType.Information, "Version", versionJson);
        }
    }
}