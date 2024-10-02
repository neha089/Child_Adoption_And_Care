<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrphanProfile.aspx.cs" Inherits="child_a_c.Crud.OrphanProfile" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Orphanage Profile</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
        }
        h2 {
            text-align: center;
            color: #333;
        }
        .profile-container {
            max-width: 600px;
            margin: auto;
            background: white;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            padding: 20px;
        }
        .profile-detail {
            margin-bottom: 15px;
            padding: 10px;
            border-bottom: 1px solid #eee;
        }
        label {
            font-weight: bold;
            color: #555;
        }
        asp:Label {
            display: block;
            margin-top: 5px;
            color: #333;
            padding: 8px;
            background: #f9f9f9;
            border-radius: 4px;
            border: 1px solid #ddd;
        }
        .edit-button {
            display: block;
            width: 100%;
            padding: 10px;
            border: none;
            border-radius: 5px;
            background-color: #5cb85c;
            color: white;
            font-size: 16px;
            cursor: pointer;
            text-align: center;
            text-decoration: none;
        }
        .edit-button:hover {
            background-color: #4cae4c;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="profile-container">
            <h2>Orphanage Profile</h2>
            <div class="profile-detail">
                <label>Name:</label>
                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
            </div>
            <div class="profile-detail">
                <label>Address:</label>
                <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
            </div>
            <div class="profile-detail">
                <label>Phone Number:</label>
                <asp:Label ID="lblPhoneNumber" runat="server" Text=""></asp:Label>
            </div>
            <div class="profile-detail">
                <label>Email:</label>
                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
            </div>
            <div class="profile-detail">
                <label>Contact Person:</label>
                <asp:Label ID="lblContactPerson" runat="server" Text=""></asp:Label>
            </div>
            <div class="profile-detail">
                <label>Capacity:</label>
                <asp:Label ID="lblCapacity" runat="server" Text=""></asp:Label>
            </div>
            <div class="profile-detail">
                <label>Number of Children:</label>
                <asp:Label ID="lblNumberOfChildren" runat="server" Text=""></asp:Label>
            </div>
            <div class="profile-detail">
                <label>License Number:</label>
                <asp:Label ID="lblLicenseNumber" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CssClass="edit-button" />
            </div>
        </div>
    </form>
</body>
</html>
