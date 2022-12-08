using demo_back.model;
using demo_proj_backend.common;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Web.Http.Cors;
using demo_back.model;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demo_back.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
    
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\LocalDb;Initial Catalog=myLocalDb;Integrated Security=True");
        string msg = String.Empty;
        db drop = new db();

        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employee> Get()
        {
            Employee emp = new Employee();
            emp.type = "getAll";
            DataSet ds = drop.EmployeeGet(emp,out msg);
            List<Employee> list = new List<Employee>();
             foreach(DataRow  dr in ds.Tables[0].Rows) {
                list.Add(new Employee
                {
                   Id = Convert.ToInt32(dr["id"]),
                   FirstName = dr["firstName"].ToString(),
                   LastName = dr["lastName"].ToString(),
                   Email = dr["email"].ToString(),
                   Mobile = dr["mobile"].ToString(),
                   Password = dr["password"].ToString(),
                   DateOfBirth = dr["dob"].ToString(),
                   CreatedAt = dr["createdAt"].ToString(),
                   UpdatedAt = dr["updatedAt"].ToString(),
                   IsActive = dr["isActive"].ToString(),
                });
            }
            return list;
        }
        
        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public List<Employee> Get(int id)
        {
            Employee emp = new Employee();
            emp.Id = id;
            emp.type = "getID";
            DataSet ds = drop.EmployeeGet(emp, out msg);
            List<Employee> list = new List<Employee>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Employee
                {
                    Id = Convert.ToInt32(dr["id"]),
                    FirstName = dr["firstName"].ToString(),
                    LastName = dr["lastName"].ToString(),
                    Email = dr["email"].ToString(),
                    Mobile = dr["mobile"].ToString(),
                    Password = dr["password"].ToString(),
                    DateOfBirth = dr["dob"].ToString(),
                    CreatedAt = dr["createdAt"].ToString(),
                    UpdatedAt = dr["updatedAt"].ToString(),
                    IsActive = dr["isActive"].ToString(),
                });
            }
            return list;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public string Post([FromBody] Employee emp)
        {
            String msg = string.Empty;
            try
            {
                emp.type = "insert";
                msg = drop.EmployeeOpt(emp);
            }
            catch(Exception ex)
            {
                msg= ex.Message;
            }
            return JsonConvert.SerializeObject(msg);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public string put(int id,[FromBody] Employee emp)
        {
            String msg = string.Empty;
            try
            {
                emp.Id = id;
                emp.type = "update";
                msg = drop.EmployeeOpt(emp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return JsonConvert.SerializeObject(msg);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            String msg = string.Empty;
            try
            {
                Employee emp=new Employee();
                emp.Id = id;    
                msg = drop.EmployeeOpt(emp);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return JsonConvert.SerializeObject(msg);
        }
    }
}
