<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Adopters.aspx.cs" Inherits="YourNamespace.Adopters" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Adopters</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Manage Adopters</h2>

            <!-- Input fields to add/update records -->
            <asp:Label ID="lblAdopterId" runat="server" Text="Adopter ID:"></asp:Label>
            <asp:TextBox ID="txtAdopterId" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblDateOfBirth" runat="server" Text="Date of Birth:"></asp:Label>
            <asp:TextBox ID="txtDateOfBirth" runat="server" TextMode="Date"></asp:TextBox><br />

            <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number:"></asp:Label>
            <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblMaritalStatus" runat="server" Text="Marital Status:"></asp:Label>
            <asp:TextBox ID="txtMaritalStatus" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblOccupation" runat="server" Text="Occupation:"></asp:Label>
            <asp:TextBox ID="txtOccupation" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblEducationLevel" runat="server" Text="Education Level:"></asp:Label>
            <asp:TextBox ID="txtEducationLevel" runat="server"></asp:TextBox><br />

            <!-- Buttons for CRUD operations -->
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />

            <!-- GridView to display records -->
            <asp:GridView ID="gvAdopters" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvAdopters_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="adopter_id" HeaderText="Adopter ID" />
                    <asp:BoundField DataField="first_name" HeaderText="First Name" />
                    <asp:BoundField DataField="last_name" HeaderText="Last Name" />
                    <asp:BoundField DataField="date_of_birth" HeaderText="Date of Birth" />
                    <asp:BoundField DataField="address" HeaderText="Address" />
                    <asp:BoundField DataField="phone_number" HeaderText="Phone Number" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="marital_status" HeaderText="Marital Status" />
                    <asp:BoundField DataField="occupation" HeaderText="Occupation" />
                    <asp:BoundField DataField="education_level" HeaderText="Education Level" />
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
