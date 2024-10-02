<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdopterCrud.aspx.cs" Inherits="AdopterCrud" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet" /> 
<head runat="server">
    <title>Orphanages</title>
<style>
    body {
    font-family: Arial, sans-serif;
    background-color: #f0f0f0;
    margin: 0;
    padding: 20px;
}

.container {
    max-width: 1200px;
    margin: auto;
}

.card, .child-card {
    background-color: #fff;
    border-radius: 10px;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    margin: 20px 0;
    padding: 20px;
    transition: transform 0.2s;
}

.card:hover, .child-card:hover {
    transform: scale(1.05);
}

h1 {
    text-align: center;
    color: #333;
}

h3, h4 {
    color: #333;
}

p {
    color: #666;
}

img.profile-img {
    width: 100px;
    height: 100px;
    border-radius: 50%;
    margin-top: 10px;
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
.top-right {
    position: absolute;
    top: 20px;
    right: 20px;
}
  .profile-icon {
            position: absolute;
            top: 20px;
            right: 20px;
            font-size: 24px;
            color: #333;
            cursor: pointer;
            text-decoration: none;
        }

        .profile-icon:hover {
            color: #218838;
        }
</style>
</head>
<body>
    <form id="form1" runat="server">
         <div class="top-right">
            <a href="UserProfile.aspx" class="profile-icon" title="Profile">
            <i class="fas fa-user-circle"></i> <!-- Font Awesome profile icon -->
        </a>
        </div>
        <div class="container">
            <h1>List of Orphanages</h1>
            <asp:Repeater ID="rptOrphanages" runat="server">
            <ItemTemplate>
            <div class="card">
            <h3><%# Eval("name") %></h3>
            <p><strong>Address:</strong> <%# Eval("address") %></p>
            <p><strong>Phone:</strong> <%# Eval("phone_number") %></p>
            <p><strong>Email:</strong> <%# Eval("email") %></p>
            <asp:Button ID="btnSelectOrphanage" runat="server" Text="View Children" 
                        CommandArgument='<%# Eval("orphanage_id") %>' OnCommand="btnSelectOrphanage_Command" />
            </div>
            </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
