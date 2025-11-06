<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AchievementsList.aspx.cs" Inherits="UserInformationSystem_v2.Pages.AchievementsList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../Css/Achievementslist.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-container">

            <div class="list-card">

                <h2>🎓 Manage Your Achievements</h2>

                <asp:Panel ID="pnlNoData" runat="server" Visible="false" CssClass="no-data-panel">
                    <p>No achievements added yet! Click below to add your first entry.</p>
                    <asp:Button ID="btnAddAchievement" runat="server" Text="Add Achievement" CssClass="btn btn-primary large-btn" OnClick="btnAddAchievement_Click" />
                </asp:Panel>

                <asp:Panel ID="pnlData" runat="server" Visible="false" CssClass="data-panel">


                    <div class="table-responsive">
                        <asp:GridView ID="gvAchievements" runat="server" AutoGenerateColumns="False" CssClass="achievement-grid">
                            <Columns>
                                <asp:BoundField DataField="ExamType" HeaderText="Exam Type" />
                                <asp:BoundField DataField="Institute" HeaderText="Institute" />
                                <asp:BoundField DataField="Grade" HeaderText="Grade" />
                                <asp:BoundField DataField="YearOfPassing" HeaderText="Year" />
                            </Columns>
                        </asp:GridView>
                    </div>

                    <div class="button-group">
                        <asp:Button ID="btnBack" runat="server" Text="Back to Dashboard" CssClass="btn btn-secondary" OnClick="btnBack_Click" />
                        <asp:Button ID="Button1" runat="server" Text="Update Achievement" CssClass="btn btn-secondary" OnClick="btnupdate_Click" />
                        <asp:Button ID="btnAddNew" runat="server" Text="Add New Achievement" CssClass="btn btn-primary" OnClick="btnAddAchievement_Click" />
                    </div>
                </asp:Panel>

            </div>
        </div>
    </form>
</body>
</html>
