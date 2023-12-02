using DotNet7StudLTE.Helpers;
using DotNet7StudLTE.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace DotNet7StudLTE.BusLogic
{
    public class Authenticate
    {
        static SqlConnection con;
        static int created = 0;
        //get all accounts created
        public static DataTable GetUserData(string Password, string Email)
        {
            DataTable dtUsers = new DataTable();
            try
            {

                dtUsers.Rows.Clear();
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("pro_Authenticate_GetUserData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Password", Password));
                    cmd.Parameters.Add(new SqlParameter("@Email", Email));
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    //SqlDataReader rdr = cmd.ExecuteReader();
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    sd.Fill(dtUsers);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteLog(ex.InnerException + "-" + ex.StackTrace, "ERROR");
            }
            return dtUsers;
        }

    }
}
