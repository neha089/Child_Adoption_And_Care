<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrphanageCrud.aspx.cs" Inherits="child_a_c.Crud.OrphanageCrud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      
            <h3>Orphanage Details</h3>
            <asp:Label Text="Orphanage ID:" runat="server" />
            <asp:TextBox ID="txtOrphanageID" runat="server" ReadOnly="true" /><br />

            <asp:Label Text="Name:" runat="server" />
            <asp:TextBox ID="txtName" runat="server" /><br />

            <asp:Label Text="Address:" runat="server" />
            <asp:TextBox ID="txtAddress" runat="server" /><br />

            <asp:Label Text="Phone Number:" runat="server" />
            <asp:TextBox ID="txtPhoneNumber" runat="server" /><br />

            <asp:Label Text="Email:" runat="server" />
            <asp:TextBox ID="txtEmail" runat="server" /><br />

            <asp:Label Text="Contact Person:" runat="server" />
            <asp:TextBox ID="txtContactPerson" runat="server" /><br />

            <asp:Label Text="Capacity:" runat="server" />
            <asp:TextBox ID="txtCapacity" runat="server" /><br />

            <asp:Label Text="Number of Children:" runat="server" />
            <asp:TextBox ID="txtNumberOfChildren" runat="server" /><br />

            <asp:Label Text="License Number:" runat="server" />
            <asp:TextBox ID="txtLicenseNumber" runat="server" /><br />

        <asp:Label Text="Password:" runat="server" />
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" /><br />

            <asp:Label Text="Confirm Password:" runat="server" />
            <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server" /><br />

            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />

            <asp:Button ID ="btnlogout" runat ="server" Text="Logout" OnClick="handleLogout" />
        </div>
    </form>
</body>
</html>
