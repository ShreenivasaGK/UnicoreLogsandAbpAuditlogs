using System.ComponentModel.DataAnnotations;

namespace LoginMVC.Models
{
    public class Login
    {
        [Key]
        
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}
