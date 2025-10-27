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
            String username = txtUsername.Text.Trim();
            String password = txtPassword.Text.Trim();

            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                Response.Write("<script>alert('Please Enter both Username and Password !')</sript>");
                return;
            }

            String conn_string = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                try
                {
                    conn.Open();

                    String query = "SELECT COUNT(*) FROM Users WHERE  Username=@username AND Password=@password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        if (chkRemember.Checked)
                        {
                            Response.Cookies["username"].Value = username;
                            Response.Cookies["username"].Expires = DateTime.Now.AddDays(7);
                        }

                        Session["Username"] = username;
                        Response.Write("<script>alert('Login Successfull');</script>");
                        Response.Redirect("register.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Username or Password !');</script>");
                    }
                }
                catch (Exception ex)
                {

                    Response.Write("<script>alert('Error : " + ex.Message + " ');</script>");
                }

            }
        }
    }
}