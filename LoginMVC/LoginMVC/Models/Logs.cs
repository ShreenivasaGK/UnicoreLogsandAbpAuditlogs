using System.ComponentModel.DataAnnotations;

namespace LoginMVC.Models
{
    public class Logs
    {
        [Key]
        public int TenantId { get; set; }
        public string InvoiceNumber { get; set; }
        public string Type { get; set; }
        public string IRRNo { get; set; }
        public string CreatedDate { get; set; }
        public string JsonData { get; set; }

        public int invoiceno {  get; set; } 
    }
}
