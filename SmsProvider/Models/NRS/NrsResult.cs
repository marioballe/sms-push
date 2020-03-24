using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Provider.Models.NSR
{
    public class NrsResult
    {
        public bool IsSuccessStatusCode { get; set; }
        public string to { get; set; }
        public bool accepted { get; set; }
        public string id { get; set; }
        public NrsError error { get; set; }
    }
}
