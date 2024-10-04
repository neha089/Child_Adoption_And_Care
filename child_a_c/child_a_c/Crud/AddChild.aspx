<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddChild.aspx.cs" Inherits="child_a_c.Crud.AddChild" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Child</title>
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
        input[type="text"], input[type="date"], input[type="file"] {
            width: 300px;
            padding: 8px;
            margin-bottom: 10px;
        }
        input[type="submit"] {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border: none;
            cursor: pointer;
        }
        input[type="submit"]:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div>
            <h2>Add Child</h2>
            <asp:Label Text="First Name:" runat="server" />
            <asp:TextBox ID="txtFirstName" runat="server" /><br />

            <asp:Label Text="Last Name:" runat="server" />
            <asp:TextBox ID="txtLastName" runat="server" /><br />

            <asp:Label Text="Date of Birth:" runat="server" />
            <asp:TextBox ID="txtDateOfBirth" runat="server" TextMode="Date" /><br />

            <asp:Label Text="Gender:" runat="server" />
            <asp:DropDownList ID="ddlGender" runat="server">
                <asp:ListItem Value="Male">Male</asp:ListItem>
                <asp:ListItem Value="Female">Female</asp:ListItem>
                <asp:ListItem Value="Other">Other</asp:ListItem>
            </asp:DropDownList><br />

            <asp:Label Text="Medical History:" runat="server" />
            <asp:TextBox ID="txtMedicalHistory" runat="server" TextMode="MultiLine" Rows="3" /><br />

            <asp:Label Text="Education Level:" runat="server" />
            <asp:TextBox ID="txtEducationLevel" runat="server" /><br />

            <asp:Label Text="Profile Image:" runat="server" />
            <asp:FileUpload ID="fuProfileImage" runat="server" /><br />

            <asp:Label Text="Document Type:" runat="server" />
            <asp:TextBox ID="txtDocumentType" runat="server" /><br />

            <asp:Label Text="Document Name:" runat="server" />
            <asp:TextBox ID="txtDocumentName" runat="server" /><br />

            <asp:Label Text="Upload Document:" runat="server" />
            <asp:FileUpload ID="fuDocument" runat="server" /><br />

            <asp:Button ID="btnAddChild" runat="server" Text="Add Child" OnClick="btnAddChild_Click" /><br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" /><br />
                      <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="submit-button" OnClick="btnBack_Click" />

        </div>
    </form>
</body>
</html>
