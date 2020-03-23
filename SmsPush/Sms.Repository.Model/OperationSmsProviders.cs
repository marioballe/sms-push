using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Repository.Model
{
    public class OperationSmsProviders
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token{ get; set; }
    }
}
