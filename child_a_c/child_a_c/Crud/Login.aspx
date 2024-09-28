<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="child_a_c.Crud.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login</h2>
            <label for="userType">Select User Type:</label>
            <asp:DropDownList ID="userType" runat="server">
                <asp:ListItem Value="Orphanage">Orphanage</asp:ListItem>
                <asp:ListItem Value="Admin">Admin</asp:ListItem>
                <asp:ListItem Value="Adopter">Adopter</asp:ListItem>
            </asp:DropDownList>

            <div>
                <label for="email">Email:</label>
                <asp:TextBox ID="email" runat="server"></asp:TextBox>
            </div>

            <div>
                <label for="password">Password:</label>
                <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
            </div>

            <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click" />
            <asp:Label ID="loginMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
