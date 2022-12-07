using System.Data;
using System.Data.SqlClient;


namespace demo_back.model
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\LocalDb;Initial Catalog=myLocalDb;Integrated Security=True\" providerName=\"System.Data.SqlClient");
        public string EmployeeOpt(Employee emp)
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
                var i = cmd.ExecuteNonQuery();
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
            return mess;

        }

        public string EmployeeGet(Employee emp)
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
                var i = cmd.ExecuteNonQuery();
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
            return mess;
        }
     }



    }
