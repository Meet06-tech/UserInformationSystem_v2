<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="UserInformationSystem_v2.Pages.dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../Css/StyleSheet1.css" />
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
        <div class="dashboard-container">
            
            <div class="top-bar">
                <img id="imgProfile" runat="server" alt="Profile Photo" class="profile-photo-main" />

                <div class="header">
                    <h2>Welcome, <asp:Label ID="lblName" runat="server" Text=""></asp:Label> 👋</h2>
                    <p class="email-display"><asp:Label ID="lblEmail" runat="server"></asp:Label></p>
                </div>
            </div>

            <div class="card-container">
                
                <div class="card profile-card">
                    <h3>Profile Management</h3>
                    <p>Manage your personal details and settings.</p>
                    <div class="button-group">
                        <asp:Button ID="btnProfile" runat="server" Text="View Details" CssClass="btn btn-primary" OnClick="btnProfile_Click" />
                        <asp:Button ID="btnEditProfile" runat="server" Text="Edit Profile" CssClass="btn btn-secondary" OnClick="btnEditProfile_Click" />
                    </div>
                </div>

                <div class="card achievement-card">
                    <h3>Achievements</h3>
                    <p>Total Achievements: <asp:Label ID="lblTotalAchievements" runat="server" Text="0"></asp:Label></p>
                    <asp:Button ID="btnAchievements" runat="server" Text="Manage Achievements" CssClass="btn btn-primary" OnClick="btnAchievements_Click" />
                </div>
            </div>

            <div class="footer-actions">
                <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="logout-btn" OnClick="btnLogout_Click" />
            </div>
            
        </div>
    </form>
</body>
</html>
