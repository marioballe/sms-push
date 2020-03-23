using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Core.Entities
{
    public class AppSettings
    {
        public short AppId { get; set; }
        public Dictionary<string, string> ConnectionStrings { get; set; }
        public bool IsDebug { get; set; }
        public Health SelfUiHealth { get; set; }
        public Health SelfLiveHealth { get; set; }
        public int NumOfAttempts { get; set; }
        public int TimeLapse { get; set; }
    }

    public class Health
    {
        public string Url { get; set; }
        public bool Active { get; set; }
    }
}
