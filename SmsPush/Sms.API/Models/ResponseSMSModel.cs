using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sms.API.Models
{
    public class ResponseSMSModel
    {
        public int IdOperation { get; set; }
        public int IdStatus { get; set; }
        public string StatusDescription { get; set; }
        public string UrlReturn { get; set; }
    }
}
