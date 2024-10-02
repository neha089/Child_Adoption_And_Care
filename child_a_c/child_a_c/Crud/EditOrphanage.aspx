<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditOrphanage.aspx.cs" Inherits="child_a_c.Crud.EditOrphanage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Orphanage Profile</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
        }

        h2 {
            color: #333;
        }

        .form-container {
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .form-group {
            margin-bottom: 15px;
        }

        label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
            color: #555;
        }

        input[type="text"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        .button-container {
            text-align: right;
        }

        .button-container asp:Button {
            padding: 10px 20px;
            margin-left: 10px;
            border: none;
            border-radius: 4px;
            background-color: #007bff;
            color: white;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        .button-container asp:Button:hover {
            background-color: #0056b3;
        }

        .button-container asp:Button[ID='btnCancel'] {
            background-color: #6c757d;
        }

        .button-container asp:Button[ID='btnCancel']:hover {
            background-color: #5a6268;
        }

        .error-message {
            color: red;
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Edit Orphanage Profile</h2>

            <div class="form-group">
                <label for="txtName">Name:</label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtAddress">Address:</label>
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtPhoneNumber">Phone Number:</label>
                <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Email:</label>
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </div>
            <div class="form-group">
                <label for="txtContactPerson">Contact Person:</label>
                <asp:TextBox ID="txtContactPerson" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtCapacity">Capacity:</label>
                <asp:TextBox ID="txtCapacity" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtNumberOfChildren">Number of Children:</label>
                <asp:TextBox ID="txtNumberOfChildren" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtLicenseNumber">License Number:</label>
                <asp:TextBox ID="txtLicenseNumber" runat="server"></asp:TextBox>
            </div>

            <div class="button-container">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </div>

            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message"></asp:Label>
        </div>
    </form>
</body>
</html>
