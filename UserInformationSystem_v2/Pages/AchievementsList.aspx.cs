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
    public partial class AchievementsList : System.Web.UI.Page
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

                    string userQuery = "SELECT UserID FROM tblUsers WHERE Username = @Username";
                    SqlCommand userCmd = new SqlCommand(userQuery, conn);
                    userCmd.Parameters.AddWithValue("@Username", Session["Username"].ToString());
                    int userId = Convert.ToInt32(userCmd.ExecuteScalar());

                    string query = "SELECT ExamType, Institute, Grade, YearOfPassing FROM tblAchievements WHERE UserID = @UserID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        pnlData.Visible = true;
                        pnlNoData.Visible = false;
                        gvAchievements.DataSource = dt;
                        gvAchievements.DataBind();
                    }
                    else
                    {
                        pnlData.Visible = false;
                        pnlNoData.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        protected void btnAddAchievement_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAchievement.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateAchievement.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("dashboard.aspx");
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateAchievement.aspx");
        }
    }
}