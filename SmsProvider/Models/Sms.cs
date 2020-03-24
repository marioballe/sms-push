using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Provider.Models
{
    public class Sms
    {
        public string From { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
    }
}
