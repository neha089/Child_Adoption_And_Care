<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChildCrud.aspx.cs" Inherits="child_a_c.Crud.ChildCrud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Children Records</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Manage Children Records</h2>
        <asp:GridView ID="gvChildren" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvChildren_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="child_id" HeaderText="Child ID" />
                <asp:BoundField DataField="first_name" HeaderText="First Name" />
                <asp:BoundField DataField="last_name" HeaderText="Last Name" />
                <asp:BoundField DataField="date_of_birth" HeaderText="Date of Birth" />
                <asp:BoundField DataField="gender" HeaderText="Gender" />
                <asp:BoundField DataField="orphanage_id" HeaderText="Orphanage ID" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>

        <h3>Child Details</h3>
        <asp:Label Text="Child ID:" runat="server" />
        <asp:TextBox ID="txtChildID" runat="server" ReadOnly="true" /><br />

        <asp:Label Text="First Name:" runat="server" />
        <asp:TextBox ID="txtFirstName" runat="server" /><br />

        <asp:Label Text="Last Name:" runat="server" />
        <asp:TextBox ID="txtLastName" runat="server" /><br />

        <asp:Label Text="Date of Birth:" runat="server" />
        <asp:TextBox ID="txtDateOfBirth" runat="server" TextMode="Date" /><br />

        <asp:Label Text="Gender:" runat="server" />
        <asp:TextBox ID="txtGender" runat="server" /><br />

        <asp:Label Text="Orphanage ID:" runat="server" />
        <asp:TextBox ID="txtOrphanageID" runat="server" /><br />

        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    </form>
</body>
</html>
