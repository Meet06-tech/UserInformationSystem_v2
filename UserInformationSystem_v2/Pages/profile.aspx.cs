using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInformationSystem_v2.Pages
{
    public partial class profile : System.Web.UI.Page
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserInfoDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] == null)
                {
                    Response.Redirect("loginform.aspx");
                }
                else
                {
                    LoadUserProfile();
                }
            }
        }

        private void LoadUserProfile()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM tblUsers WHERE Username = @Username";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", Session["Username"].ToString());

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        lblFullName.Text = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                        lblUserName.Text = "@" + reader["Username"].ToString();
                        lblEmail.Text = reader["Email"].ToString();
                        lblPhone.Text = reader["Phone"].ToString();
                        lblGender.Text = reader["Gender"].ToString();

                        if (reader["BirthDate"] != DBNull.Value)
                            lblDob.Text = Convert.ToDateTime(reader["BirthDate"]).ToString("dd MMM yyyy");

                        lblAddress.Text = reader["Address"].ToString();
                        lblCity.Text = reader["City"].ToString();
                        lblState.Text = reader["State"].ToString();

                        string photoPath = reader["Photo"].ToString();

                        if (String.IsNullOrEmpty(photoPath))
                            imgProfile.Src = ResolveUrl("~/Images/default.jpg");
                        else
                            imgProfile.Src = ResolveUrl("~/" + photoPath);

                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("updateProfile.aspx");
        }

        protected void btnAchievement_Click(object sender, EventArgs e)
        {
            Response.Redirect("AchievementsList.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("login.aspx");
        }
    }
}