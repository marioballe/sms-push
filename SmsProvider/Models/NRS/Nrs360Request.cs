using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Provider.Models.NRS
{
    public class Nrs360Request
    {
        public List<string> to { get; set; }
        public string message { get; set; }
        public string from { get; set; }
    }
}
