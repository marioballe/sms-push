using System;
using System.Collections.Generic;
using System.Text;

namespace Sms.Model.DTO
{
    public class ErrorsReportDTO
    {
        public int Id { get; set; }
        public int IdDetail { get; set; }
        public string Phone { get; set; }
        public int IdProvider { get; set; }
        public DateTime Datetime { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public int IdOperation { get; set; }
    }
}
