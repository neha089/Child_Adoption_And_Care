<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="child_a_c.Crud.UserProfile" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Profile</title>
    <style>
        .container {
            max-width: 600px;
            margin: 50px auto;
            padding: 20px;
            background-color: #fff;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
        }

        label {
            font-weight: bold;
            margin-top: 10px;
            display: block;
        }

        input[type="text"], input[type="date"], input[type="email"] {
            width: 100%;
            padding: 10px;
            margin: 5px 0 20px 0;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        button {
            background-color: #28a745;
            color: white;
            border: none;
            padding: 10px 15px;
            border-radius: 5px;
            cursor: pointer;
        }

        button:hover {
            background-color: #218838;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>User Profile</h2>

            <label for="firstName">First Name</label>
            <asp:TextBox ID="txtFirstName" runat="server" />

            <label for="lastName">Last Name</label>
            <asp:TextBox ID="txtLastName" runat="server" />

            <label for="email">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" />

            <label for="phoneNumber">Phone Number</label>
            <asp:TextBox ID="txtPhoneNumber" runat="server" />

            <label for="address">Address</label>
            <asp:TextBox ID="txtAddress" runat="server" />

            <label for="dob">Date of Birth</label>
            <asp:TextBox ID="txtDOB" runat="server" />

            <button type="submit" runat="server" onserverclick="UpdateProfile">Update Profile</button>
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="submit-button" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>
