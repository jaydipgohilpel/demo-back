using demo_back.model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Web.Http.Cors;
using System.Reflection;
using demo_proj_backend.Models;
using System.Net.Http;
using demo_back.Handler;
using Microsoft.Extensions.Configuration;
using demo_back.comman;
using System.Globalization;
using System.Net.Http.Formatting;
using Microsoft.SqlServer.Server;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace demo_back.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class EmployeeController : ControllerBase
    {

        string msg = String.Empty;
        BoEmployee drop = new BoEmployee();
        PostDataResponseHelper Responce = new PostDataResponseHelper();
        GetDataResponseHelper GetDataResponce = new GetDataResponseHelper();

        // GET: api/<EmployeeController>
        [HttpGet]
        public GetDataResponseHelper Get()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.Type = "getAll";
            DataSet ds = drop.GetEmployeeDetailsByIdAndAll(emp, out msg);
            List<EmployeeModel> list = new List<EmployeeModel>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new EmployeeModel
                {
                    Id = ((int?)dr["id"]),
                    FirstName = dr["firstName"].ToString(),
                    LastName = dr["lastName"].ToString(),
                    Email = dr["email"].ToString(),
                    Mobile = dr["mobile"].ToString(),
                    Password =dr["password"].ToString(),
                    DateOfBirth = dr["dob"].ToString(),
                    CreatedAt = dr["createdAt"].ToString(),
                    UpdatedAt =dr["updatedAt"].ToString(),
                    IsActive = (int?)dr["isActive"],
                });
            }
            GetDataResponce.Data = list;
            return GetDataResponce;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public List<EmployeeModel> Get(int id)
        {
            EmployeeModel emp = new EmployeeModel();
            emp.Id = id;
            emp.Type = "getID";
            DataSet ds = drop.GetEmployeeDetailsByIdAndAll(emp, out msg);
            List<EmployeeModel> list = new List<EmployeeModel>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new EmployeeModel
                {
                    Id = ((int?)dr["id"]),
                    FirstName = dr["firstName"].ToString(),
                    LastName = dr["lastName"].ToString(),
                    Email = dr["email"].ToString(),
                    Mobile = dr["mobile"].ToString(),
                    Password = dr["password"].ToString(),
                    DateOfBirth = dr["dob"].ToString(),
                    CreatedAt = dr["createdAt"].ToString(),
                    UpdatedAt = dr["updatedAt"].ToString(),
                    IsActive = (int?)dr["isActive"],
                });
            }
            return list;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public PostDataResponseHelper Post([FromBody] EmployeeModel emp)
        {

            var formData = new MultipartFormDataContent();
            String msg = string.Empty;
            try
            {
                emp.Type = "insert";
                msg = drop.AddAndUpdatEmployeeDetails(emp);
            }
            catch (Exception ex)
            {

                Responce.Status = (int)HttpStatusCode.BadRequest;
                Responce.Message = ex.Message;
                Responce.StatusText = "BadRequest";
                Responce.Headers = "Registraion Failed ,Record is Not Inserted.";
                Responce.Ok = false;
                return Responce;

            }
            Responce.Status = (int)HttpStatusCode.Created;
            Responce.Message = msg;
            Responce.StatusText = "Created";
            Responce.Ok=true;
            return Responce;

        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public PostDataResponseHelper put(int id, [FromBody] EmployeeModel emp)
        {
            String msg = string.Empty;
            try
            {
                emp.Id = id;
                emp.Type = "update";
                msg = drop.AddAndUpdatEmployeeDetails(emp);
            }
            catch (Exception ex)
            {
                Responce.Status = (int)HttpStatusCode.BadRequest;
                Responce.Message = ex.Message;
                Responce.StatusText = "BadRequest";
                Responce.Headers = "Updation Failed , Record is not Updated, ";
                Responce.Ok = false;
                return Responce;
            }
            Responce.Status = (int)HttpStatusCode.OK;
            Responce.Message = msg;
            Responce.StatusText = "Ok";
            Responce.Ok = true;
            return Responce;

        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public PostDataResponseHelper Delete(int id)
        {
            String msg = string.Empty;
            try
            {
                EmployeeModel emp = new EmployeeModel();
                emp.Id = id;
                emp.Type = "delete";
                msg = drop.DeleteEmployeeDetails(emp);
            }
            catch (Exception ex)
            {
                Responce.Status = (int)HttpStatusCode.BadRequest;
                Responce.Message = ex.Message;
                Responce.StatusText = "BadRequest";
                Responce.Headers = "Deletion Failed , Record is not Deleted, ";
                Responce.Ok = false;
                return Responce;
          
            }
            Responce.Status = (int)HttpStatusCode.OK;
            Responce.Message = msg;
            Responce.StatusText = "Ok";
            Responce.Ok = true;

            return Responce;
           
        }
    }
}
