using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;



namespace demo_back.model
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\LocalDb;Initial Catalog=myLocalDb;Integrated Security=True");
        public string EmployeeOpt(Employee emp)
        {
            string mess = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Registration]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstName", emp.FirstName);
                cmd.Parameters.AddWithValue("@lastName", emp.LastName);
                cmd.Parameters.AddWithValue("@email", emp.Email);
                cmd.Parameters.AddWithValue("@mobile", emp.Mobile);
                cmd.Parameters.AddWithValue("@password", emp.Password);
                cmd.Parameters.AddWithValue("@dob", emp.DateOfBirth);
                cmd.Parameters.AddWithValue("@type", emp.type);
                if(emp.type=="update" || emp.type=="delete")
                {
                    cmd.Parameters.AddWithValue("@id", emp.Id);
                }
                con.Open();
               var i= cmd.ExecuteNonQuery();
                con.Close();
                mess = "successfully.";
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
            return JsonConvert.SerializeObject(mess);
        }
        public DataSet EmployeeGet(Employee emp,out string msg)
        {
             msg = string.Empty;
            DataSet ds= new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[GetData]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", emp.type);
                cmd.Parameters.AddWithValue("@id", emp.Id);
                SqlDataAdapter da=new SqlDataAdapter(cmd);
                da.Fill(ds);
                msg = "SUCCESS";   
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return ds;
        }
        

    }

}
