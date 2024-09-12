<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplicationRecords.aspx.cs" Inherits="child_a_c.Crud.ApplicationRecords" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Application Records</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Manage Application Records</h2>
        <asp:GridView ID="gvApplicationRecords" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvApplicationRecords_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="application_id" HeaderText="Application ID" />
                <asp:BoundField DataField="adopter_id" HeaderText="Adopter ID" />
                <asp:BoundField DataField="child_id" HeaderText="Child ID" />
                <asp:BoundField DataField="application_date" HeaderText="Application Date" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>

        <!-- Application Details -->
        <h3>Application Details</h3>
        <asp:Label Text="Application ID:" runat="server" />
        <asp:TextBox ID="txtApplicationID" runat="server" ReadOnly="true" /><br />

        <asp:Label Text="Adopter ID:" runat="server" />
        <asp:TextBox ID="txtAdopterID" runat="server" /><br />

        <asp:Label Text="Child ID:" runat="server" />
        <asp:TextBox ID="txtChildID" runat="server" /><br />

        <asp:Label Text="Application Date:" runat="server" />
        <asp:TextBox ID="txtApplicationDate" runat="server" /><br />

        <asp:Label Text="Status:" runat="server" />
        <asp:TextBox ID="txtStatus" runat="server" /><br />

        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    </form>
</body>
</html>