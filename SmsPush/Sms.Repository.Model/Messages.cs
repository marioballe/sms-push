using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Repository.Model
{
    public class Messages
    {
        public int Id { get; set; }
        public int IdTemplate { get; set; }
        public int IdLanguage { get; set; }
        public string NameFrom { get; set; }
        public string Message { get; set; }
        public bool Enable { get; set; }
        public string CustomCode { get; set; }
    }
}
