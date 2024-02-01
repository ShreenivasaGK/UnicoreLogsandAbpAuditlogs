namespace LoginMVC.Models
{
    public class UnicoreLogRequest
    {
        //public int InvoiceNumber { get; set; }
        public string  MethodName { get; set; }
        public string Parametets { get; set; }
        public  string  ServiceName{ get; set; }
        public int TenantId { get; set; }
        public int UserId { get; set; }
       
    }
}
