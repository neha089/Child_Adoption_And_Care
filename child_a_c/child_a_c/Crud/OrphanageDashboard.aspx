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
            margin: 0;
        }

        li {
            margin: 15px 0;
            text-align: center;
        }

        a, .logout-button {
            text-decoration: none;
            padding: 12px 20px;
            color: white;
            background-color: #007BFF;
            border-radius: 5px;
            transition: background-color 0.3s;
            display: inline-block;
            border: none;
            cursor: pointer;
        }

        a:hover, .logout-button:hover {
            background-color: #0056b3;
        }

        .logout-button {
            background-color: #dc3545;
        }

        .logout-button:hover {
            background-color: #c82333;
        }

        footer {
            text-align: center;
            margin-top: 20px;
            font-size: 14px;
            color: #777;
        }

        .table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .table th, .table td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: center;
        }

        .table th {
            background-color: #007BFF;
            color: white;
        }

        .status-btn {
            margin-right: 5px;
            padding: 5px 10px;
            color: white;
            border: none;
            cursor: pointer;
        }

        .accepted {
            background-color: #28a745;
        }

        .rejected {
            background-color: #dc3545;
        }

        .btn {
            background-color: #007BFF;
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

            <asp:Label ID="lblSuccessMessage" runat="server" Visible="false" ForeColor="Green" />
            <asp:Label ID="lblErrorMessage" runat="server" Visible="false" ForeColor="Red" />

            <asp:GridView ID="gvApplicationRecords" runat="server" AutoGenerateColumns="False" CssClass="table" OnRowCommand="OnRowCommand">
                <Columns>
                    <asp:BoundField DataField="application_id" HeaderText="Application ID" />
                    <asp:BoundField DataField="adopter_name" HeaderText="Adopter Name" />
                    <asp:BoundField DataField="child_id" HeaderText="Child ID" />
                    <asp:BoundField DataField="application_date" HeaderText="Application Date" />
                    <asp:BoundField DataField="status" HeaderText="Status" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnAccept" runat="server" CommandName="Accept" CommandArgument='<%# Eval("application_id") %>' CssClass="status-btn accepted" Text="Accept" />
                            <asp:Button ID="btnReject" runat="server" CommandName="Reject" CommandArgument='<%# Eval("application_id") %>' CssClass="status-btn rejected" Text="Reject" />
                            <asp:Button ID="btnViewDocuments" runat="server" CommandName="ViewDocuments" CommandArgument='<%# Eval("application_id") %>' CssClass="status-btn btn" Text="View Documents" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
    <footer>Orphanage Child Adoption Platform</footer>
</body>
</html>
