using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Repository.Model
{
    public class ConsumerToken
    {
        public int Id { get; set; }
        public int IdApp{ get; set; }
        public int IdPortal { get; set; }
        public int IdProvider { get; set; }
        public string Token { get; set; }
    }
}
