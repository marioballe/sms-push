using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sms.API.Models
{
    public class RequestSMSModel
    {
        public int IdObject { get; set; }
        public int IdMessage { get; set; }
        public int IdLanguage { get; set; }
        public string Phone { get; set; }
        public string CustomCode { get; set; }
        public string UrlReturn { get; set; }
    }
}
