<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_crud.aspx.cs" Inherits="child_a_c.Crud.admin_crud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Management</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Manage Admins</h2>
            <asp:GridView ID="gvAdmins" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvAdmins_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="admin_id" HeaderText="Admin ID" />
                    <asp:BoundField DataField="username" HeaderText="Username" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="role" HeaderText="Role" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>

            <h3>Admin Details</h3>
            <asp:Label Text="Admin ID:" runat="server" />
            <asp:TextBox ID="txtAdminID" runat="server" ReadOnly="true" /><br />

            <asp:Label Text="Username:" runat="server" />
            <asp:TextBox ID="txtUsername" runat="server" /><br />

            <asp:Label Text="Password:" runat="server" />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /><br />

            <asp:Label Text="First Name:" runat="server" />
            <asp:TextBox ID="txtFirstName" runat="server" /><br />

            <asp:Label Text="Last Name:" runat="server" />
            <asp:TextBox ID="txtLastName" runat="server" /><br />

            <asp:Label Text="Email:" runat="server" />
            <asp:TextBox ID="txtEmail" runat="server" /><br />

            <asp:Label Text="Phone Number:" runat="server" />
            <asp:TextBox ID="txtPhoneNumber" runat="server" /><br />

            <asp:Label Text="Role:" runat="server" />
            <asp:TextBox ID="txtRole" runat="server" /><br />

            <asp:Label Text="Status:" runat="server" />
            <asp:TextBox ID="txtStatus" runat="server" /><br />

            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
    </form>
</body>
</html>
