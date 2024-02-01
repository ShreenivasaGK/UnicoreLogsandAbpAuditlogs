using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoginMVC.Data;
using LoginMVC.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;

namespace LoginMVC.Controllers
{
    public class LoginsController : Controller
    {

        private readonly IConfiguration _configuration;
       


        private readonly LoginMVCContext _context;

        public LoginsController(LoginMVCContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]

        public IActionResult Login(Login login)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("cns")))
                {

                    using (SqlCommand cmd = new SqlCommand("Fetching", con))
                    {
                          con.Open();
                          cmd.CommandType = System.Data.CommandType.StoredProcedure;
                          cmd.Parameters.AddWithValue("@Email", login.EmailId);
                          cmd.Parameters.AddWithValue("@Pass", login.Password);
                          var userCount = (int)cmd.ExecuteScalar();
                            if (userCount == 1)
                            {

                            return View("Add");
                        }
                        else
                            {
                                TempData["msg"] = userCount;
                                return View("Login");
                            }
                    }

                }
              
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return View();

        }

    }
}
