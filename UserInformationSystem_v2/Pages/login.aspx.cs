using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInformationSystem_v2.Pages
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Response.Write("<script>alert('Please enter both Username and Password!');</script>");
                return;
            }

            string conn_string = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM tblUsers WHERE Username=@Username AND Password=@Password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        
                        Session["Username"] = username;

                       
                        if (chkRemember.Checked)
                        {
                            Response.Cookies["username"].Value = username;
                            Response.Cookies["username"].Expires = DateTime.Now.AddDays(7);
                        }

                        Response.Write("<script>alert('Login Successful!');</script>");
                        Response.Redirect("profile.aspx"); 
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Username or Password!');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }
    }
}