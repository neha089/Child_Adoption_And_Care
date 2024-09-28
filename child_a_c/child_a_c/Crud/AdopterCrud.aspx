<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="AdopterCrud.aspx.cs" Inherits="child_a_c.Crud.AdopterCrud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Adopters</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Manage Adopters</h2>
            <asp:GridView ID="gvAdopters" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvAdopters_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="adopter_id" HeaderText="Adopter ID" />
                    <asp:BoundField DataField="first_name" HeaderText="First Name" />
                    <asp:BoundField DataField="last_name" HeaderText="Last Name" />
                    <asp:BoundField DataField="date_of_birth" HeaderText="Date of Birth" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="address" HeaderText="Address" />
                    <asp:BoundField DataField="phone_number" HeaderText="Phone Number" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="marital_status" HeaderText="Marital Status" />
                    <asp:BoundField DataField="occupation" HeaderText="Occupation" />
                    <asp:BoundField DataField="education_level" HeaderText="Education Level" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>

            <h3>Adopter Details</h3>
            <asp:Label Text="Adopter ID:" runat="server" />
            <asp:TextBox ID="txtAdopterID" runat="server" ReadOnly="true" /><br />

            <asp:Label Text="First Name:" runat="server" />
            <asp:TextBox ID="txtFirstName" runat="server" /><br />

            <asp:Label Text="Last Name:" runat="server" />
            <asp:TextBox ID="txtLastName" runat="server" /><br />

            <asp:Label Text="Date of Birth:" runat="server" />
            <asp:TextBox ID="txtDateOfBirth" runat="server" TextMode="Date" /><br />

            <asp:Label Text="Address:" runat="server" />
            <asp:TextBox ID="txtAddress" runat="server" /><br />

            <asp:Label Text="Phone Number:" runat="server" />
            <asp:TextBox ID="txtPhoneNumber" runat="server" /><br />

            <asp:Label Text="Email:" runat="server" />
            <asp:TextBox ID="txtEmail" runat="server" /><br />

            <asp:Label Text="Marital Status:" runat="server" />
            <asp:TextBox ID="txtMaritalStatus" runat="server" /><br />

            <asp:Label Text="Occupation:" runat="server" />
            <asp:TextBox ID="txtOccupation" runat="server" /><br />

            <asp:Label Text="Education Level:" runat="server" />
            <asp:TextBox ID="txtEducationLevel" runat="server" /><br />

            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
    </form>
</body>
</html>
