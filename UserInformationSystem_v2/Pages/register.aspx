<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="UserInformationSystem_v2.Pages.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../Css/StyleSheet.css" />
    <title></title>
</head>
<body>
    <div class="container">
     <h2>User Register</h2>
     <form id="formRegister" runat="server">
         <div class="form-group">
             <label for="txtFirstName">First Name :</label>
             <asp:TextBox ID="txtFirstName" runat="server" CssClass="input-control"></asp:TextBox>
         </div>

         <div class="form-group">
             <label for="txtLastName">Last Name :</label>
             <asp:TextBox ID="txtLastName" runat="server" CssClass="input-control"></asp:TextBox>
         </div>

         <div class="form-group gender-group">
             <label>Gender:</label>
             <div class="gender-options">
                 <asp:RadioButton ID="rbMale" runat="server" GroupName="Gender" Text="Male" />
                 <asp:RadioButton ID="rbFemale" runat="server" GroupName="Gender" Text="Female" />
             </div>
         </div>


         <div class="form-group">
             <label>Date of Birth :</label>
             <asp:TextBox ID="txtDOB" runat="server" CssClass="input-control" TextMode="Date"></asp:TextBox>
         </div>

         <div class="form-group">
             <label>Email :</label>
             <asp:TextBox ID="txtEmail" runat="server" CssClass="input-control" TextMode="Email"></asp:TextBox>
         </div>

         <div class="form-group">
             <label>Phone NO :</label>
             <asp:TextBox ID="txtPhone" runat="server" CssClass="input-control"></asp:TextBox>
         </div>

         <div class="form-group">
             <label>Address :</label>
             <asp:TextBox ID="txtAddress" runat="server" CssClass="input-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
         </div>

         <div class="form-group">
             <label>City :</label>
             <asp:TextBox ID="txtCity" runat="server" CssClass="input-control"></asp:TextBox>
         </div>

         <div class="form-group">
             <label>State :</label>
             <asp:TextBox ID="txtState" runat="server" CssClass="input-control"></asp:TextBox>
         </div>

         <div class="form-group">
             <label>PinCode :</label>
             <asp:TextBox ID="txtPincode" runat="server" CssClass="input-control"></asp:TextBox>
         </div>

         <div class="form-group">
             <label>User Name :</label>
             <asp:TextBox ID="txtUsername" runat="server" CssClass="input-control"></asp:TextBox>
         </div>

         <div class="form-group">
             <label>Password :</label>
             <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input-control"></asp:TextBox>
         </div>

         <div class="form-group">
             <label>Upload Photo :</label>
             <asp:FileUpload ID="filePhoto" runat="server" CssClass="input-file" />
         </div>

         <div class="form-group">
             <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn" OnClick="btnRegister_Click" />
         </div>
     </form>
</body>
</html>
