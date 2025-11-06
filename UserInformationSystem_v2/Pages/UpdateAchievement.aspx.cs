using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInformationSystem_v2.Pages
{
    public partial class UpdateAchievement : System.Web.UI.Page
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserInfoDB;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] == null)
                {
                    Response.Redirect("login.aspx");
                    return;
                }

                LoadAchievements();
            }
        }

        private void LoadAchievements()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    
                    string userQuery = "SELECT UserID FROM tblUsers WHERE Username=@Username";
                    SqlCommand userCmd = new SqlCommand(userQuery, conn);
                    userCmd.Parameters.AddWithValue("@Username", Session["Username"].ToString());
                    int userId = Convert.ToInt32(userCmd.ExecuteScalar());

                    
                    string query = "SELECT AchievementID, ExamType, Institute, Grade, YearOfPassing FROM tblAchievements WHERE UserID=@UserID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gvAchievements.DataSource = dt;
                    gvAchievements.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error loading data: {ex.Message}');</script>");
            }
        }



        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("dashboard.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAchievement.aspx");
        }
        protected void gvAchievements_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAchievements.EditIndex = e.NewEditIndex;
            LoadAchievements();
        }

        protected void gvAchievements_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAchievements.EditIndex = -1;
            LoadAchievements();
        }

        protected void gvAchievements_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvAchievements.Rows[e.RowIndex];
            int achievementId = Convert.ToInt32(gvAchievements.DataKeys[e.RowIndex].Value);

            string examType = ((TextBox)row.Cells[1].Controls[0]).Text.Trim();
            string institute = ((TextBox)row.Cells[2].Controls[0]).Text.Trim();
            string grade = ((TextBox)row.Cells[3].Controls[0]).Text.Trim();
            string year = ((TextBox)row.Cells[4].Controls[0]).Text.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string updateQuery = @"UPDATE tblAchievements 
                                           SET ExamType=@ExamType, Institute=@Institute, Grade=@Grade, YearOfPassing=@Year 
                                           WHERE AchievementID=@AchievementID";

                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@ExamType", examType);
                    cmd.Parameters.AddWithValue("@Institute", institute);
                    cmd.Parameters.AddWithValue("@Grade", grade);
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@AchievementID", achievementId);

                    cmd.ExecuteNonQuery();
                }

                gvAchievements.EditIndex = -1;
                LoadAchievements();
                Response.Write("<script>alert('Achievement updated successfully!');</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error updating record: {ex.Message}');</script>");
            }
        }

        protected void gvAchievements_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int achievementId = Convert.ToInt32(gvAchievements.DataKeys[e.RowIndex].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM tblAchievements WHERE AchievementID=@AchievementID";
                    SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@AchievementID", achievementId);
                    cmd.ExecuteNonQuery();
                }

                LoadAchievements();
                Response.Write("<script>alert('Achievement deleted successfully!');</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error deleting record: {ex.Message}');</script>");
            }
        }

        protected void gvAchievements_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}