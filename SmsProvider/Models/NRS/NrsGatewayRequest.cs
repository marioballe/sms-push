using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Provider.Models.NSR
{
    public class NrsGatewayRequest
    {
        public List<string> to { get; set; }
        public string text { get; set; }
        public string from { get; set; }
    }
}
