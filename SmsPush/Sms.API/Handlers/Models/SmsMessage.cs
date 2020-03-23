using MediatR;
using Sms.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sms.API.Handlers.Models
{
    public class SmsMessage : IRequest<ResponseSMSModel>
    {
        public int IdObject { get; set; }
        public int IdMessage { get; set; }
        public int IdLanguage { get; set; }
        public string Phone { get; set; }
        public string CustomCode { get; set; }
        public string UrlReturn { get; set; }
        public string Token { get; set; }
    }
}
