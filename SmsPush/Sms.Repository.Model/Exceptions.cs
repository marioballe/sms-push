using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Repository.Model
{
    public class Exceptions
    {
        public int Id { get; set; }
        public DateTime Datetime { get; set; }
        public string Message { get; set; }
        public string ServerName { get; set; }
        public string ServerIP { get; set; }
        public string Method { get; set; }
        public string Class { get; set; }
        public string Target { get; set; }
        public string Source { get; set; }
        public string Exception { get; set; }
        public string InnerException { get; set; }
    }
}
