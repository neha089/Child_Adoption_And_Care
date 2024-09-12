<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Children.aspx.cs" Inherits="Children" %>

<!DOCTYPE html>
<html>
<head>
    <title>Children</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Manage Children</h2>
        <asp:GridView ID="gvChildren" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvChildren_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="child_id" HeaderText="Child ID" />
                <asp:BoundField DataField="first_name" HeaderText="First Name" />
                <asp:BoundField DataField="last_name" HeaderText="Last Name" />
                <asp:BoundField DataField="date_of_birth" HeaderText="Date of Birth" />
                <asp:BoundField DataField="gender" HeaderText="Gender" />
                <asp:BoundField DataField="orphanage_id" HeaderText="Orphanage ID" />
                <asp:BoundField DataField="adopter_id" HeaderText="Adopter ID" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>

        <!-- Child Details -->
        <h3>Child Details</h3>
        <asp:Label Text="Child ID:" runat="server" />
        <asp:TextBox ID="txtChildID" runat="server" ReadOnly="true" /><br />

        <asp:Label Text="First Name:" runat="server" />
        <asp:TextBox ID="txtFirstName" runat="server" /><br />

        <asp:Label Text="Last Name:" runat="server" />
        <asp:TextBox ID="txtLastName" runat="server" /><br />

        <asp:Label Text="Date of Birth:" runat="server" />
        <asp:TextBox ID="txtDateOfBirth" runat="server" /><br />

        <asp:Label Text="Gender:" runat="server" />
        <asp:TextBox ID="txtGender" runat="server" /><br />

        <asp:Label Text="Orphanage ID:" runat="server" />
        <asp:TextBox ID="txtOrphanageID" runat="server" /><br />

        <asp:Label Text="Adopter ID:" runat="server" />
        <asp:TextBox ID="txtAdopterID" runat="server" /><br />

        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    </form>
</body>
</html>
