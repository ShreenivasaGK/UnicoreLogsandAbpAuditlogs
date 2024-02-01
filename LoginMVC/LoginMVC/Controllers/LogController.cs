using LoginMVC.Data;
using LoginMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using System.Data;

namespace LoginMVC.Controllers
{
    public class LogController : Controller
    {
        private readonly IConfiguration _configuration;



        private readonly LoginMVCContext _context;

        public LogController(LoginMVCContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IActionResult Log(List<Logs> log)
        {
            log = Fetch();
            return View(log);
        }

        public List<Logs> Fetch()
        {
            List<Logs> log = new List<Logs>();


            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("cns")))
            {

                using (SqlCommand cmd = new SqlCommand("FetchingLogs", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Logs logs = new Logs();
                        logs.TenantId = Convert.ToInt32(reader["tenantid"]);

                        logs.InvoiceNumber = reader["invoiceNumber"].ToString();
                        logs.Type = reader["Type"].ToString();
                        logs.IRRNo = reader["irrno"].ToString();
                        logs.CreatedDate = reader["CreatedDate"].ToString();
                        logs.JsonData = reader["JsonObject"].ToString();




                        log.Add(logs);
                    }
                    reader.Close();

                }
            }
            return log;
        }




        [HttpGet]
        public IActionResult LogsXML(List<LogsXML> log)
        {
            log = FetchLogXML();
            return View(log);
        }

        public List<LogsXML> FetchLogXML()
        {
            List<LogsXML> log = new List<LogsXML>();


            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("cns")))
            {

                using (SqlCommand cmd = new SqlCommand("FetchingLogsandxmllogs", con))
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        LogsXML logs = new LogsXML();
                        logs.batchid = Convert.ToInt32(reader["batchid"]);
                        logs.json = reader["json"].ToString();
                        logs.tenantid = Convert.ToInt32(reader["tenantid"]);
                        logs.csid = Convert.ToString(reader["csid"]);
                        logs.CompInvRes = Convert.ToString(reader["complianceInvoiceResponse"]);
                        logs.cleRes = Convert.ToString(reader["clearanceResponse"]);
                        logs.totalamt = Convert.ToDecimal(reader["totalAmount"]);
                        logs.vatamt = Convert.ToDecimal(reader["vatAmount"]);

                        log.Add(logs);
                    }
                    reader.Close();

                }
            }
            return log;
        }
        

        
     
      

        //public IActionResult FetchRequestData(string textBoxValue)
        //{
        //    List<UnicoreLogRequest> log = new List<UnicoreLogRequest>();



        //    using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("cns")))
        //    {

        //        using (SqlCommand cmd = new SqlCommand("FetchingAuditandUnicoreLogs", con))
        //        {
        //            con.Open();
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            //cmd.Parameters.AddWithValue("@InvoiceNum", textBoxValue);
        //            //cmd.Parameters.AddWithValue("@InvoiceNum", textBoxValue ?? DBNull.Value);
        //            cmd.Parameters.AddWithValue("@InvoiceNum", string.IsNullOrEmpty(textBoxValue) ? DBNull.Value : (object)textBoxValue);

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {

        //                while (reader.Read())
        //                {
        //                    UnicoreLogRequest logs = new UnicoreLogRequest();
        //                    logs.MethodName = reader["methodname"].ToString();
        //                    logs.Parametets = reader["parameters"].ToString();
        //                    logs.ServiceName = reader["ServiceName"].ToString();
        //                    logs.TenantId = Convert.ToInt32(reader["TenantId"]);
        //                    logs.UserId = Convert.ToInt32(reader["UserId"]);
        //                    log.Add(logs);
        //                }
        //                reader.Close();
        //            }
        //        }
        //    }
        //    return View(log);
        //}

          [HttpGet]
        public IActionResult FetchRequestData(string textBoxValue)
        {
           

            List<UnicoreLogRequest> log = new List<UnicoreLogRequest>();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("cns")))
            {
                using (SqlCommand cmd = new SqlCommand("FetchingAuditandUnicoreLogs", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                   

                    cmd.Parameters.AddWithValue("@InvoiceNum", "212369");
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                        while (reader.Read())
                        {
                            UnicoreLogRequest logs = new UnicoreLogRequest();
                            logs.MethodName = reader["methodname"].ToString();
                            logs.Parametets = reader["parameters"].ToString();
                            logs.ServiceName = reader["ServiceName"].ToString();
                            logs.TenantId = Convert.ToInt32(reader["TenantId"]);
                            logs.UserId = Convert.ToInt32(reader["UserId"]);
                            log.Add(logs);
                        }
              
                }
            }

            return View(log);
        }

    }
}

    

