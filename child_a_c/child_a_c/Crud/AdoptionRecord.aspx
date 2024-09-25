<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdoptionRecord.aspx.cs" Inherits="Crud.AdoptionRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Adoption Records</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Manage Adoption Records</h2>
        <asp:GridView ID="gvAdoptionRecords" runat="server" AutoGenerateColumns="False" 
                      OnSelectedIndexChanged="gvAdoptionRecords_SelectedIndexChanged" 
                      CssClass="grid-view">
            <Columns>
                <asp:BoundField DataField="adoption_id" HeaderText="Adoption ID" />
                <asp:BoundField DataField="adopter_id" HeaderText="Adopter ID" />
                <asp:BoundField DataField="child_id" HeaderText="Child ID" />
                <asp:BoundField DataField="adoption_date" HeaderText="Adoption Date" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>

        <!-- Adoption Details -->
        <h3>Adoption Details</h3>
        <asp:Label Text="Adoption ID:" runat="server" AssociatedControlID="txtAdoptionID" />
        <asp:TextBox ID="txtAdoptionID" runat="server" ReadOnly="true" /><br />

        <asp:Label Text="Adopter ID:" runat="server" AssociatedControlID="txtAdopterID" />
        <asp:TextBox ID="txtAdopterID" runat="server" /><br />

        <asp:Label Text="Child ID:" runat="server" AssociatedControlID="txtChildID" />
        <asp:TextBox ID="txtChildID" runat="server" /><br />

        <asp:Label Text="Adoption Date:" runat="server" AssociatedControlID="txtAdoptionDate" />
        <asp:TextBox ID="txtAdoptionDate" runat="server" /><br />

        <asp:Label Text="Status:" runat="server" AssociatedControlID="txtStatus" />
        <asp:TextBox ID="txtStatus" runat="server" /><br />

        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    </form>
</body>
</html>
