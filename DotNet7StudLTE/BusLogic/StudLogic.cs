using DotNet7StudLTE.Helpers;
using System.Data.SqlClient;
using System.Data;

namespace DotNet7StudLTE.BusLogic
{
    public class StudLogic
    {
        static SqlConnection con;
        static int created = 0;

        //get all products
        public static DataTable GetStudentData()
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("pro_Student_GetStudentInformation", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@crtRoleId", RoleId));
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    sd.Fill(dt);
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public static DataTable GetStudentDepartmentData()
        {
            DataTable dtDept = new DataTable();
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("pro_Student_GetDepartmentInformation", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@crtRoleId", RoleId));
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    sd.Fill(dtDept);
                }
            }
            catch (Exception ex)
            {

            }
            return dtDept;
        }

        public static int SaveNewStudentData(int studID, string FirstName, string Surname, int DepartmentID, DateTime Birthday)
        {

            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("pro_Student_SaveNewStudentData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@StudentID", studID));
                    cmd.Parameters.Add(new SqlParameter("@FirstName", FirstName));
                    cmd.Parameters.Add(new SqlParameter("@Surname", Surname));
                    cmd.Parameters.Add(new SqlParameter("@DepartmentID", DepartmentID));
                    cmd.Parameters.Add(new SqlParameter("@Birthday", Birthday));

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    //return success or failure
                    created = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {

            }
            return created;
        }

        public static DataTable GetStudentDepartmentDataById(int studentID)
        {
            DataTable dtStud = new DataTable();
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("pro_Student_GetStudentInformationByID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@studentID", studentID));
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    sd.Fill(dtStud);
                }
            }
            catch (Exception ex)
            {

            }
            return dtStud;
        }


        //make a branch inactive.
        public static int DeleteStudentData(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("pro_Student_DeleteStudentID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@studentID", Convert.ToInt32(id)));
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




        //make student active.
        public static int ActivateStudent(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("pro_Student_ActivateStudentID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@studentID", Convert.ToInt32(id)));
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


        //get all products
        public static DataTable GetInactiveStudentData()
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("pro_Student_GetInactiveStudentInformation", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@crtRoleId", RoleId));
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    sd.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteLog(ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace, "ERROR");
            }
            return dt;
        }


        //get all products
        public static DataSet GetAttendanceStudentData()
        {
            DataSet dt = new DataSet();
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("pro_Student_GetAttendanceInformation", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@crtRoleId", RoleId));
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    sd.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteLog(ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace, "ERROR");
            }
            return dt;
        }


        //get all products
        public static DataSet GetStudentTotalsData()
        {
            DataSet dt = new DataSet();
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("pro_Student_GetTotalsInformation", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add(new SqlParameter("@crtRoleId", RoleId));
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataAdapter sd = new SqlDataAdapter(cmd);
                    sd.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.WriteLog(ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace, "ERROR");
            }
            return dt;
        }

        //update user theme
        public static int UpdateUserTheme(int UserID)
        {
            DataSet dt = new DataSet();
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("pro_Student_UpdateUserLightTheme", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UserID", UserID));
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
                ErrHandler.WriteLog(ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace, "ERROR");
            }
            return created;
        }


        //update user theme
        public static int UpdateUserDarkTheme(int UserID)
        {
            DataSet dt = new DataSet();
            try
            {
                using (con = new SqlConnection(Constants.DATABASE_URL))
                {
                    SqlCommand cmd = new SqlCommand("pro_Student_UpdateUserDarkTheme", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UserID", UserID));
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
                ErrHandler.WriteLog(ex.Message + " - " + ex.InnerException + " - " + ex.StackTrace, "ERROR");
            }
            return created;
        }
    }
}
