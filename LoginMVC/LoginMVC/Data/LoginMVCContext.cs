using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoginMVC.Models;

namespace LoginMVC.Data
{
    public class LoginMVCContext : DbContext
    {
        public LoginMVCContext (DbContextOptions<LoginMVCContext> options)
            : base(options)
        {
        }

        public DbSet<LoginMVC.Models.Login> Login { get; set; } = default!;
        public DbSet<LoginMVC.Models.Logs> Logs { get; set; } = default!;
        public DbSet<LoginMVC.Models.UnicoreLogRequest> UnicoreLogRequests { get;}
        //public DbSet<LoginMVC.Models.LogsXML> Logsxml { get; set; } = default!;
    }
}
