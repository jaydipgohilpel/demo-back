using demo_back.model;
using demo_proj_backend.common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Web.Http.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demo_back.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
    
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\LocalDb;Initial Catalog=myLocalDb;Integrated Security=True");
        // GET: api/<EmployeeController>
        //[HttpGet]
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */
        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public string Post([FromBody] Employee emp)
        {
            string mess = string.Empty;
            try
            {

                SqlCommand cmd = new SqlCommand("[dbo].[insertRegistration]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstName", emp.FirstName);
                cmd.Parameters.AddWithValue("@lastName", emp.LastName);
                cmd.Parameters.AddWithValue("@email", emp.Email);
                cmd.Parameters.AddWithValue("@mobile", emp.Mobile);
                cmd.Parameters.AddWithValue("@password", emp.Password);
                cmd.Parameters.AddWithValue("@dob", emp.DateOfBirth);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                mess = "Registered has been successfully.";
            }
            catch (Exception ex)
            {
                mess = ex.Message;
            }

            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            string output = JsonConvert.SerializeObject(mess);
            return mess;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
