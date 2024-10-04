<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrphanageList.aspx.cs" Inherits="child_a_c.Crud.OrphanageList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Orphanage List</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            padding: 20px;
        }
        .container {
            text-align: center;
        }
        .card {
            border: 1px solid #ddd;
            border-radius: 10px;
            padding: 20px;
            margin: 20px;
            width: 350px;
            display: inline-block;
            background-color: white;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            transition: transform 0.2s ease;
        }
        .card:hover {
            transform: translateY(-5px);
        }
        .card h3 {
            margin-top: 0;
            color: #333;
        }
        .card p {
            margin: 5px 0;
        }
        .btn-donate {
            background-color: #28a745;
            color: white;
            padding: 10px 15px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            text-decoration: none;
            margin-top: 15px;
        }
        .btn-donate:hover {
            background-color: #218838;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Repeater ID="RepeaterOrphanages" runat="server">
                <ItemTemplate>
                    <div class="card">
                        <h3><%# Eval("name") %></h3>
                        <p>Address: <%# Eval("address") %></p>
                        <p>Contact: <%# Eval("phone_number") %></p>
                        <p>Email: <%# Eval("email") %></p>
                        <asp:Button ID="btnDonate" runat="server" CssClass="btn-donate" Text="Donate" CommandArgument='<%# Eval("orphanage_id") %>' OnClick="btnDonate_Click" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
