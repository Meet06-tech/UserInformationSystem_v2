<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAchievement.aspx.cs" Inherits="UserInformationSystem_v2.Pages.AddAchievement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../Css/achievements.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="form-card">

            <h2>➕ Add New Achievement</h2>
            <div class="subtitle">Enter details for your completed qualification or course.</div>

            <
            <div class="input-group">
                <label for="<%= txtExamType.ClientID %>">Exam Type</label>
                <asp:TextBox ID="txtExamType" runat="server" CssClass="input" placeholder="e.g., Bachelor of Science"></asp:TextBox>
            </div>

            
            <div class="input-group">
                <label for="<%= txtInstitute.ClientID %>">Institute</label>
                <asp:TextBox ID="txtInstitute" runat="server" CssClass="input" placeholder="e.g., Harvard University"></asp:TextBox>
            </div>

            
            <div class="input-group">
                <label for="<%= txtGrade.ClientID %>">Grade / Score</label>
                <asp:TextBox ID="txtGrade" runat="server" CssClass="input" placeholder="e.g., A+ or 92%"></asp:TextBox>
            </div>

            
            <div class="input-group">
                <label for="<%= txtYear.ClientID %>">Year of Passing</label>
                <asp:TextBox ID="txtYear" runat="server" CssClass="input" placeholder="e.g., 2023"></asp:TextBox>
            </div>
            
            <div class="button-actions">
                <asp:Button ID="btnSave" runat="server" Text="Save Achievement" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnBack" runat="server" Text="Back to Manage" CssClass="btn btn-secondary" OnClick="btnBack_Click" />
            </div>
            
        </div>
    </form>
</body>
</html>
