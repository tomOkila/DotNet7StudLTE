using DotNet7StudLTE.Helpers;
using System.Data.SqlClient;
using System.Data;

namespace DotNet7StudLTE.BusLogic
{
    public class BranchLogic
    {
        static SqlConnection con;
        static int created = 0;
        static DataTable dt = new DataTable();

        //get all branches
        public static DataTable GetBranchData()
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("pro_Branch_GetBranchData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    //SqlDataReader rdr = cmd.ExecuteReader();
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    sd.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteLog(ex.InnerException + "-" + ex.StackTrace, "ERROR");
            }
            return dt;
        }


        //create new branch
        public static int CreateBranch(string branchName, string description, string street1, string street2, string city, string province, string country,Boolean isDefaultBranch)
        {
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("pro_Branch_CreateBranchData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@branchId", branchId));
                    cmd.Parameters.Add(new SqlParameter("@branchName", branchName));
                    cmd.Parameters.Add(new SqlParameter("@description", description));
                    cmd.Parameters.Add(new SqlParameter("@street1", street1));
                    cmd.Parameters.Add(new SqlParameter("@street2", street2));
                    cmd.Parameters.Add(new SqlParameter("@city", city));
                    cmd.Parameters.Add(new SqlParameter("@province", province));
                    cmd.Parameters.Add(new SqlParameter("@country", country));
                    cmd.Parameters.Add(new SqlParameter("@isDefaultBranch", isDefaultBranch));
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    //SqlDataReader rdr = cmd.ExecuteReader();
                    created = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteLog(ex.Message + "-" + ex.StackTrace, "ERROR");
            }
            return created;
        }


        //get all branches
        public static DataTable GetBranchDataByID(string id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("pro_Branch_GetBranchDataByID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@branchID", Convert.ToInt32(id)));
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    //SqlDataReader rdr = cmd.ExecuteReader();
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    sd.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteLog(ex.InnerException + "-" + ex.StackTrace, "ERROR");
            }
            return dt;
        }


        //create new branch
        public static int EditBranch(int?branchID,string branchName, string description, string street1, string street2, string city, string province, string country, Boolean isDefaultBranch)
        {
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("pro_Branch_EditBranchData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@branchId", branchID));
                    cmd.Parameters.Add(new SqlParameter("@branchName", branchName));
                    cmd.Parameters.Add(new SqlParameter("@description", description));
                    cmd.Parameters.Add(new SqlParameter("@street1", street1));
                    cmd.Parameters.Add(new SqlParameter("@street2", street2));
                    cmd.Parameters.Add(new SqlParameter("@city", city));
                    cmd.Parameters.Add(new SqlParameter("@province", province));
                    cmd.Parameters.Add(new SqlParameter("@country", country));
                    cmd.Parameters.Add(new SqlParameter("@isDefaultBranch", isDefaultBranch));
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    //SqlDataReader rdr = cmd.ExecuteReader();
                    created = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteLog(ex.Message + "-" + ex.StackTrace, "ERROR");
            }
            return created;
        }



        //make a branch inactive.
        public static int DeleteBranchData(string id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("pro_Branch_DeleteBranchID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@branchID", Convert.ToInt32(id)));
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    created = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteLog(ex.InnerException + "-" + ex.StackTrace, "ERROR");
            }
            return created;
        }


        //get suspended branches
        public static DataTable GetSuspendedBranchData()
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("pro_Branch_GetSuspendedBranchData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    //SqlDataReader rdr = cmd.ExecuteReader();
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    sd.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteLog(ex.InnerException + "-" + ex.StackTrace, "ERROR");
            }
            return dt;
        }




        //make a branch active.
        public static int ActivateBranch(string id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("pro_Branch_ActivateBranchID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@branchID", Convert.ToInt32(id)));
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    created = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteLog(ex.InnerException + "-" + ex.StackTrace, "ERROR");
            }
            return created;
        }


    }
}
