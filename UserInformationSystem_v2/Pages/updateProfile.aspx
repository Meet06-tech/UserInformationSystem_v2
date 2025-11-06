<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateProfile.aspx.cs" Inherits="UserInformationSystem_v2.Pages.updateProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="../Css/updateprofile.css" />
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
        <div class="edit-container">
            <div class="edit-card">
                <h2>Edit Profile</h2>
                
                <div class="form-grid">
                   
                    <div class="form-group">
                        <label>First Name</label>
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="input-box"></asp:TextBox>
                    </div>
                    
                    
                    <div class="form-group">
                        <label>Last Name</label>
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="input-box"></asp:TextBox>
                    </div>
                    
                    <div class="form-group">
                        <label>Gender</label>
                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="input-box">
                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    
                    <div class="form-group">
                        <label>Date of Birth</label>
                        <asp:TextBox ID="txtBirthDate" runat="server" CssClass="input-box" TextMode="Date"></asp:TextBox>
                    </div>
                    
                    <div class="form-group">
                        <label>Email</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="input-box"></asp:TextBox>
                    </div>
                    
                    <div class="form-group">
                        <label>Phone</label>
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="input-box"></asp:TextBox>
                    </div>
                    
                    <div class="form-group">
                        <label>City</label>
                        <asp:TextBox ID="txtCity" runat="server" CssClass="input-box"></asp:TextBox>
                    </div>
                    
                    <div class="form-group">
                        <label>State</label>
                        <asp:TextBox ID="txtState" runat="server" CssClass="input-box"></asp:TextBox>
                    </div>
                    
                   
                    <div class="form-group form-group-full">
                        <label>Address</label>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="input-box" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    
                    <div class="form-group form-group-full">
                        <label>Profile Photo</label>
                        <asp:FileUpload ID="fuPhoto" runat="server" CssClass="file-upload" />
                    </div>
                </div>
                
                <div class="btn-group">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn save-btn" Text="Save Changes" OnClick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" CssClass="btn cancel-btn" Text="Cancel" OnClick="btnCancel_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
