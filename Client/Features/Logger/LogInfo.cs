using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Features.Logger
{
    public class LogInfo
    {
        public DateTime Created_DateTime { get; set; }
        public LogType LogType { get; set; }
        public string MemberName { get; set; }
        public string SourcePath { get; set; }
        public int SourceLine { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
    }
}
