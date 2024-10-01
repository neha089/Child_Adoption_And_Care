<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>
<html>
<head>
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Login</h2>
        <label>Email:</label>
        <asp:TextBox ID="txtEmail" runat="server" /><br />
        <label>Password:</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /><br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
    </form>
</body>
</html>
