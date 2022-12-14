using demo_back.comman;
using demo_back.model;
using demo_back.Model;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace demo_back.Handler
{
    public class BoFileUpoads
    {
        SqlConnection _Connection = new SqlConnection(DatabaseConnection.AccessConnectionString());
        public string AddAndUpdatEmployeeDetails(FileUploads fileObj)
        {
            string mess = string.Empty;
            try
            {
              
                SqlCommand cmd = new SqlCommand("[dbo].[UploadedFileByEmployee]", _Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FileName", fileObj.FileName);
                cmd.Parameters.AddWithValue("@FileType", fileObj.FileType);
                cmd.Parameters.AddWithValue("@FileUrl", fileObj.FileUrl);
               
           
                _Connection.Open();
                int i = cmd.ExecuteNonQuery();
                _Connection.Close();
                mess = "File Uploaded Successfully.";
            }
            catch (Exception ex)
            {
                mess = ex.Message;
            }

            finally
            {
                if (_Connection.State == ConnectionState.Open)
                {
                    _Connection.Close();
                }
            }
            return mess;
        }
       /* public string DeleteEmployeeDetails(EmployeeModel emp)
        {
            string mess = string.Empty;
            try
            {
                string SpName = PassTypeGetSpName(emp.Type);

                SqlCommand cmd = new SqlCommand(SpName, _Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", emp.Id);
             
                _Connection.Open();
                var i = cmd.ExecuteNonQuery();
                _Connection.Close();
                mess = "Delete Successfully.";
            }
            catch (Exception ex)
            {
                mess = ex.Message;
            }
            finally
            {
                if (_Connection.State == ConnectionState.Open)
                {
                    _Connection.Close();
                }
            }
            return mess;
        }
        public DataSet GetEmployeeDetailsByIdAndAll(EmployeeModel emp, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                string SpName = PassTypeGetSpName(emp.Type);

                SqlCommand cmd = new SqlCommand(SpName, _Connection);
                cmd.CommandType = CommandType.StoredProcedure;
               
                if (emp.Type == "getID")
                {
                    cmd.Parameters.AddWithValue("@id", emp.Id);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "Successfully.";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
       
        private string PassTypeGetSpName(string empType)
        {
            
            if (empType == "insert")
            {
                return  "[dbo].[NewEmployeeRegistration]";
            }
            else if (empType == "update")
            {
                return  "[dbo].[UpdateEmployeeRecord]";
            }
            else if (empType == "getID")
            {
                return  "[dbo].[GetEmployeeDataById]";
            }
            else if (empType == "getAll")
            {
                return  "[dbo].[GetAllEmployeeData]";
            }
            else if (empType == "delete")
            {
                return  "[dbo].[DeleteEmployeeRecord]";
            }
            return "";
        }*/

    }  

}
