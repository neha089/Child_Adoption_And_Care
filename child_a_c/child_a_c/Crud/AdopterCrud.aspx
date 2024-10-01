<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdopterCrud.aspx.cs" Inherits="child_a_c.Crud.AdopterCrud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Adopters</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }
        h2 {
            color: #4CAF50;
        }
        label {
            display: inline-block;
            margin: 10px 0 5px;
        }
        input[type="text"], input[type="date"] {
            width: 300px;
            padding: 8px;
            margin-bottom: 10px;
        }
        input[type="submit"], button {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border: none;
            cursor: pointer;
        }
        input[type="submit"]:hover, button:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Manage Adopters</h2>

            <h3>Adopter Details</h3>

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

            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /><br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
        </div>
    </form>
</body>
</html>
