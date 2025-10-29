using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserInformationSystem_v2.Pages
{
    public partial class updateProfile : System.Web.UI.Page
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserInfoDB;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] == null)
                    Response.Redirect("login.aspx");
                else
                    LoadUserData();
            }
        }

        private void LoadUserData()
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
                    txtFirstName.Text = reader["FirstName"].ToString();
                    txtLastName.Text = reader["LastName"].ToString();
                    ddlGender.SelectedValue = reader["Gender"].ToString();
                    txtBirthDate.Text = reader["BirthDate"] != DBNull.Value ? Convert.ToDateTime(reader["BirthDate"]).ToString("yyyy-MM-dd") : "";
                    txtEmail.Text = reader["Email"].ToString();
                    txtPhone.Text = reader["Phone"].ToString();
                    txtAddress.Text = reader["Address"].ToString();
                    txtCity.Text = reader["City"].ToString();
                    txtState.Text = reader["State"].ToString();
                }
                reader.Close();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string photoPath = "";

            if (fuPhoto.HasFile)
            {
                string folderPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string fileName = Path.GetFileName(fuPhoto.FileName);
                string fullPath = Path.Combine(folderPath, fileName);
                fuPhoto.SaveAs(fullPath);
                photoPath = "Uploads/" + fileName;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE tblUsers SET 
                                FirstName=@FirstName, LastName=@LastName, Gender=@Gender, BirthDate=@BirthDate, 
                                Email=@Email, Phone=@Phone, Address=@Address, City=@City, State=@State" +
                                (fuPhoto.HasFile ? ", Photo=@Photo" : "") +
                                " WHERE Username=@Username";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@BirthDate", txtBirthDate.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@City", txtCity.Text.Trim());
                cmd.Parameters.AddWithValue("@State", txtState.Text.Trim());
                cmd.Parameters.AddWithValue("@Username", Session["Username"].ToString());
                if (fuPhoto.HasFile)
                    cmd.Parameters.AddWithValue("@Photo", photoPath);

                cmd.ExecuteNonQuery();
            }

            Response.Write("<script>alert('Profile updated successfully!'); window.location='profile.aspx';</script>");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("profile.aspx");
        }
    }
}