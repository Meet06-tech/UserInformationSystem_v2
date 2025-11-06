<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateAchievement.aspx.cs" Inherits="UserInformationSystem_v2.Pages.UpdateAchievement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../Css/updateAchievement.css" />
    <title></title>
    <style type="text/css">
        .achievement-grid {}
    </style>
</head>
<body>
  <form id="form1" runat="server">
        <div id="achievement-container">

            <h2>✏️ Manage Your Achievements</h2>
            <p class="subtitle">Edit, delete, or add new achievements to keep your profile updated.</p>

            <asp:GridView ID="gvAchievements" runat="server" AutoGenerateColumns="False" CssClass="achievement-grid"
                DataKeyNames="AchievementID" 
                OnRowEditing="gvAchievements_RowEditing"
                OnRowUpdating="gvAchievements_RowUpdating"
                OnRowCancelingEdit="gvAchievements_RowCancelingEdit"
                OnRowDeleting="gvAchievements_RowDeleting" Height="196px" OnSelectedIndexChanged="gvAchievements_SelectedIndexChanged" Width="546px">

                <Columns>
                    <asp:BoundField DataField="AchievementID" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="ExamType" HeaderText="Exam Type" />
                    <asp:BoundField DataField="Institute" HeaderText="Institute" />
                    <asp:BoundField DataField="Grade" HeaderText="Grade" />
                    <asp:BoundField DataField="YearOfPassing" HeaderText="Year" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>

                <HeaderStyle CssClass="grid-header" />
                <RowStyle CssClass="grid-row" />
                <AlternatingRowStyle CssClass="grid-alt-row" />
                <EditRowStyle CssClass="grid-edit-row" />
            </asp:GridView>

            <div class="button-group">
                <asp:Button ID="btnAdd" runat="server" Text="➕ Add New Achievement" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
                <asp:Button ID="btnBack" runat="server" Text="← Back to Dashboard" CssClass="btn btn-secondary" OnClick="btnBack_Click" />
            </div>

        </div>
    </form>
</body>
</html>
