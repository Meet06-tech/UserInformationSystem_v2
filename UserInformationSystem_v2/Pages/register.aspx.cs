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
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string conn_string = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UserInfoDB;Integrated Security=True";

            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string gender = rbMale.Checked ? "Male" : rbFemale.Checked ? "Female" : "";
            DateTime birthDate = DateTime.Parse(txtDOB.Text);
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string city = txtCity.Text.Trim();
            string state = txtState.Text.Trim();
            string pincode = txtPincode.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string photoPath = "";

            if (filePhoto.HasFile)
            {
                string folderpath = Server.MapPath("~/uploads/");
                if (!Directory.Exists(folderpath))
                {
                    Directory.CreateDirectory(folderpath);
                }

                string filename = Path.GetFileName(filePhoto.FileName);
                string fullpath = Path.Combine(folderpath, filename);
                filePhoto.SaveAs(fullpath);
                photoPath = "uploads/" + filename;
            }

            string query = @"INSERT INTO tblUsers 
                            (Firstname, Lastname, Gender, Birthdate, Email, Phone, Address, Pincode, City, State, Username, Password, Photo) 
                            VALUES (@Firstname, @Lastname, @Gender, @Birthdate, @Email, @Phone, @Address, @Pincode, @City, @State, @Username, @Password, @Photo)";

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Firstname", firstName);
                    cmd.Parameters.AddWithValue("@Lastname", lastName);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Birthdate", birthDate);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Pincode", pincode);
                    cmd.Parameters.AddWithValue("@City", city);
                    cmd.Parameters.AddWithValue("@State", state);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Photo", photoPath);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();


                        Response.Write("<script>alert('Registration Successful! Redirecting to login page...');</script>");
                        Response.Redirect("loginform.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('Registration Failed: " + ex.Message + "');</script>");
                    }
                }
            }
        }
    }
}