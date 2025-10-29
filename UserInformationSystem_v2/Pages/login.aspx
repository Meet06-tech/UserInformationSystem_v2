<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="UserInformationSystem_v2.Pages.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../Css/register.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container login-container">
        <h2>Login</h2>
        <div class="form-group">
            <label>UserName :</label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="input-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label>Password :</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input-control"></asp:TextBox>
        </div>

        <div class="form-group remember-group">
            <asp:CheckBox ID="chkRemember" runat="server" />
            <label for="chkRemember">Remember Me</label>
        </div>

        <div class="form-group">
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />
        </div>

        <div class="form-group">
            <p class="link">Don't have an account ?<a href="register.aspx">Register Here </a></p>
        </div>
    </div>
</form>
</body>
</html>
