using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInformationSystem_v2.Pages
{
    public partial class AddAchievement : System.Web.UI.Page
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserInfoDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                   
                    string userQuery = "SELECT UserID FROM tblUsers WHERE Username=@Username";
                    SqlCommand getUserCmd = new SqlCommand(userQuery, conn);
                    getUserCmd.Parameters.AddWithValue("@Username", Session["Username"].ToString());
                    int userId = Convert.ToInt32(getUserCmd.ExecuteScalar());

                    
                    string insertQuery = @"INSERT INTO tblAchievements 
                                          (UserID, ExamType, Institute, Grade, YearOfPassing)
                                          VALUES (@UserID, @ExamType, @Institute, @Grade, @Year)";

                    SqlCommand cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@ExamType", txtExamType.Text.Trim());
                    cmd.Parameters.AddWithValue("@Institute", txtInstitute.Text.Trim());
                    cmd.Parameters.AddWithValue("@Grade", txtGrade.Text.Trim());
                    cmd.Parameters.AddWithValue("@Year", txtYear.Text.Trim());

                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert('Achievement Added Successfully!');window.location='ManageAchievements.aspx';</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AchievementsList.aspx");
        }
    }
}