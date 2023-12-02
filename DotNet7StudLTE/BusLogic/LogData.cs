using DotNet7StudLTE.Helpers;
using System.Data.SqlClient;
using System.Data;

namespace DotNet7StudLTE.BusLogic
{
    public class LogData
    {
        static SqlConnection con;
        static int created = 0;
        public static void LogSessionData(string UserId, string RoleId, string principleIdentity, string ResultBody)
        {
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("pro_Authenticate_LogUserData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UserId", UserId));
                    cmd.Parameters.Add(new SqlParameter("@RoleId", RoleId));
                    cmd.Parameters.Add(new SqlParameter("@principleIdentity", principleIdentity));
                    cmd.Parameters.Add(new SqlParameter("@ResultBody", ResultBody));
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();

                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteLog(ex.InnerException + "-" + ex.StackTrace, "ERROR");
            }
        }
    }
}
