using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInformationSystem_v2.Pages
{
    public partial class dashboard : System.Web.UI.Page
    {
        string conn_string = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserInfoDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] == null)
                    Response.Redirect("login.aspx");
                else
                    LoadDashboardData();
            }
        }
        private void LoadDashboardData()
        {
            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                conn.Open();
                string userQuery = "SELECT FirstName, LastName, Email, Photo, UserID FROM tblUsers WHERE Username=@Username";
                SqlCommand cmd = new SqlCommand(userQuery, conn);
                cmd.Parameters.AddWithValue("@Username", Session["Username"].ToString());

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblName.Text = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                    lblEmail.Text = reader["Email"].ToString();
                    imgProfile.Src = String.IsNullOrEmpty(reader["Photo"].ToString())
                        ? "../Images/default.jpg"
                        : "../" + reader["Photo"].ToString();
                    ViewState["UserID"] = reader["UserID"].ToString();
                }
                reader.Close();

                string achQuery = "SELECT COUNT(*) FROM tblAchievements WHERE UserID=@UserID";
                SqlCommand achCmd = new SqlCommand(achQuery, conn);
                achCmd.Parameters.AddWithValue("@UserID", ViewState["UserID"]);
                lblTotalAchievements.Text = achCmd.ExecuteScalar().ToString();
            }
        }

        protected void btnAchievements_Click(object sender, EventArgs e)
        {
            Response.Redirect("AchievementsList.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("login.aspx");
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("profile.aspx");
        }

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("updateProfile.aspx");
        }
    }
}