<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="UserInformationSystem_v2.Pages.profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <link rel="stylesheet" href="../Css/profile.css" />
    <title></title>

</head>
<body>
   <form id="form1" runat="server">
        <div class="container profile-container">
            <h2 class="page-title">My Profile</h2>
            
            <div class="profile-card">
                <div class="profile-header">
                    <img id="imgProfile" runat="server" alt="profile photo" class="profile-photo" />
                    <div class="profile-name">
                        <h2><asp:Label ID="lblFullName" runat="server" Text=""></asp:Label></h2>
                        <p class="username">@<asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></p>
                    </div>
                </div>

                <div class="profile-details-grid">
                    <div class="detail-column">
                        <p><strong>Email :</strong> <asp:Label ID="lblEmail" runat="server"></asp:Label></p>
                        <p><strong>Phone :</strong> <asp:Label ID="lblPhone" runat="server"></asp:Label></p>
                        <p><strong>Gender :</strong> <asp:Label ID="lblGender" runat="server"></asp:Label></p>
                        <p><strong>Birth Date :</strong> <asp:Label ID="lblDob" runat="server"></asp:Label></p>
                    </div>

                    <div class="detail-column">
                        <p><strong>Address :</strong> <asp:Label ID="lblAddress" runat="server"></asp:Label></p>
                        <p><strong>City :</strong> <asp:Label ID="lblCity" runat="server"></asp:Label></p>
                        <p><strong>State :</strong> <asp:Label ID="lblState" runat="server"></asp:Label></p>
                    </div>
                </div>

                <div class="button-group">
                    <asp:Button ID="btnEdit" runat="server" CssClass="btn" Text="Edit Profile" OnClick="btnEdit_Click" />
                    <asp:Button ID="btnAchievement" runat="server" CssClass="btn" Text="My Achievements" OnClick="btnAchievement_Click" />
                    <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn logout-btn" OnClick="btnLogout_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
