using System;

namespace Sms.Repository.Model
{
    public class Operations
    {
        public int Id { get; set; }
        public int IdBusiness { get; set; }
        public int IdProduct { get; set; }
        public int IdPortal { get; set; }
        public int IdLanguage { get; set; }
        public int IdOrigin { get; set; }
        public int IdObject { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UrlReturn { get; set; }
        public int IdStatus { get; set; }
        public int IdTemplate { get; set; }

    }
}
