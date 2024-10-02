<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrphanageDashboard.aspx.cs" Inherits="child_a_c.Crud.OrphanageDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Orphanage Dashboard</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
        }

        h2 {
            color: #333;
            text-align: center;
            margin-bottom: 10px;
        }

        h3 {
            color: #555;
            text-align: center;
            margin-bottom: 30px;
        }

        .container {
            max-width: 800px;
            margin: auto;
            background: white;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            padding: 20px;
        }

        ul {
            list-style-type: none;
            padding: 0;
            margin: 0; /* Remove default margin from ul */
        }

        li {
            margin: 15px 0; /* Set margin below each button */
            text-align: center;
        }

        a {
            text-decoration: none;
            padding: 12px 20px;
            color: white;
            background-color: #007BFF; /* Bootstrap Primary color */
            border-radius: 5px;
            transition: background-color 0.3s;
            display: inline-block; /* Ensure links behave like block elements */
            border: none; /* Remove default border from button */
            cursor: pointer; /* Change cursor to pointer */
        }

        a:hover {
            background-color: #0056b3; /* Darker shade on hover */
        }

        .logout-button {
            padding: 12px 20px; /* Same padding as links */
            background-color: #dc3545; /* Bootstrap Danger color */
            border-radius: 5px; /* Rounded corners */
            border: none; /* Remove border */
            color: white; /* Text color */
            cursor: pointer; /* Pointer cursor */
            transition: background-color 0.3s; /* Transition effect */
        }

        .logout-button:hover {
            background-color: #c82333; /* Darker shade on hover */
        }

        footer {
            text-align: center;
            margin-top: 20px;
            font-size: 14px;
            color: #777;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" method="post">
        <div class="container">
            <h2>Orphanage Dashboard</h2>
            <h3>Welcome, <%= Session["OrphanageName"] ?? "Orphanage" %>!</h3>
            <ul>
                <li><a href="OrphanProfile.aspx">Profile</a></li>
                <li><a href="AddChild.aspx">Add Child</a></li>
                <li>
                    <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="logout-button" />
                </li>
            </ul>
        </div>
        <footer>
            <p>&copy; 2024 Orphanage Management System. All Rights Reserved.</p>
        </footer>
    </form>
</body>
</html>
