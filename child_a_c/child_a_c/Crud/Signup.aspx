<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="child_a_c.Crud.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Signup Page</title>
    <style>
        .form-group {
            margin-bottom: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Signup</h2>

            <div class="form-group">
                <label for="userType">Select User Type:</label>
                <asp:DropDownList ID="userType" runat="server">
                    <asp:ListItem Value="Orphanage">Orphanage</asp:ListItem>
                    <asp:ListItem Value="Admin">Admin</asp:ListItem>
                    <asp:ListItem Value="Adopter">Adopter</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="username">Username:</label>
                <asp:TextBox ID="username" runat="server" required="required"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="password">Password:</label>
                <asp:TextBox ID="password" runat="server" TextMode="Password" required="required"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="email">Email:</label>
                <asp:TextBox ID="email" runat="server" required="required"></asp:TextBox>
            </div>

            <div class="form-group" id="additionalFields" runat="server" visible="false">
                <div>
                    <label for="additionalInfo">Additional Information:</label>
                    <asp:TextBox ID="additionalInfo" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>

            <asp:Button ID="signupButton" runat="server" Text="Sign Up" OnClick="signupButton_Click" />

        </div>
    </form>

    <script>
        document.getElementById('<%= userType.ClientID %>').addEventListener('change', function () {
            var additionalFields = document.getElementById('<%= additionalFields.ClientID %>');
            additionalFields.style.display = this.value === 'Orphanage' ? 'block' : 'none';
            additionalFields.visible = this.value === 'Orphanage';
        });
    </script>
</body>
</html>
