using System;
using System.Collections.Generic;
using System.Data;
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
            string conn_string = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserInfoDB;Integrated Security=True";

            // --- Collect user input ---
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string gender = rbMale.Checked ? "Male" : rbFemale.Checked ? "Female" : "";

            // --- Validate date ---
            DateTime birthDate;
            if (!DateTime.TryParse(txtDOB.Text, out birthDate))
            {
                Response.Write("<script>alert('Please enter a valid date of birth.');</script>");
                return;
            }

            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string city = txtCity.Text.Trim();
            string state = txtState.Text.Trim();
            string pincode = txtPincode.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string photoPath = "";

            // --- Handle photo upload ---
            if (filePhoto.HasFile)
            {
                string folderpath = Server.MapPath("~/uploads/");
                if (!Directory.Exists(folderpath))
                    Directory.CreateDirectory(folderpath);

                string filename = Path.GetFileNameWithoutExtension(filePhoto.FileName);
                string extension = Path.GetExtension(filePhoto.FileName);
                filename = filename + "_" + DateTime.Now.Ticks + extension;

                string fullpath = Path.Combine(folderpath, filename);
                filePhoto.SaveAs(fullpath);
                photoPath = "uploads/" + filename;
            }

            // --- Insert data using ADO.NET ---
            string query = @"INSERT INTO tblUsers 
                            (Firstname, Lastname, Gender, Birthdate, Email, Phone, Address, Pincode, City, State, Username, Password, Photo)
                            VALUES (@Firstname, @Lastname, @Gender, @Birthdate, @Email, @Phone, @Address, @Pincode, @City, @State, @Username, @Password, @Photo)";

            using (SqlConnection conn = new SqlConnection(conn_string))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@Firstname", SqlDbType.NVarChar, 50).Value = firstName;
                    cmd.Parameters.Add("@Lastname", SqlDbType.NVarChar, 50).Value = lastName;
                    cmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 10).Value = gender;
                    cmd.Parameters.Add("@Birthdate", SqlDbType.Date).Value = birthDate;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email;
                    cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 15).Value = phone;
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 200).Value = address;
                    cmd.Parameters.Add("@Pincode", SqlDbType.NVarChar, 10).Value = pincode;
                    cmd.Parameters.Add("@City", SqlDbType.NVarChar, 50).Value = city;
                    cmd.Parameters.Add("@State", SqlDbType.NVarChar, 50).Value = state;
                    cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = password;
                    cmd.Parameters.Add("@Photo", SqlDbType.NVarChar, 200).Value = photoPath;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        // Success alert and redirect
                        Response.Write("<script>alert('Registration Successful! Redirecting to login page...'); window.location='login.aspx';</script>");
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627) // Unique username constraint
                            Response.Write("<script>alert('Username already exists. Please choose another.');</script>");
                        else
                            Response.Write("<script>alert('Registration failed: " + ex.Message + "');</script>");
                    }
                }
            }
        }
    }
}