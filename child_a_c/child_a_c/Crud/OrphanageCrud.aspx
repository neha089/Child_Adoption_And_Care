<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrphanageCrud.aspx.cs" Inherits="child_a_c.Crud.OrphanageCrud" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Orphanage Details</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }
        .child-form {
            display: none;
            margin-top: 20px;
        }
    </style>
    <script>
        function showChildForm() {
            document.getElementById('childForm').style.display = 'block';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Orphanage List</h3>
            <asp:GridView ID="gvOrphanages" runat="server" AutoGenerateColumns="true" OnSelectedIndexChanged="gvOrphanages_SelectedIndexChanged"></asp:GridView>

            <h3>Orphanage Details</h3>
            <asp:Label Text="Orphanage ID:" runat="server" />
            <asp:TextBox ID="txtOrphanageID" runat="server" ReadOnly="true" /><br />

            <asp:Label Text="Name:" runat="server" />
            <asp:TextBox ID="txtName" runat="server" /><br />

            <!-- Other orphanage details go here -->

            <asp:Button ID="btnAddChild" runat="server" Text="Add Child" OnClientClick="showChildForm(); return false;" /><br />

            <div id="childForm" class="child-form">
                <h3>Add Child Details</h3>
                <asp:Label Text="First Name:" runat="server" />
                <asp:TextBox ID="txtChildFirstName" runat="server" /><br />

                <asp:Label Text="Last Name:" runat="server" />
                <asp:TextBox ID="txtChildLastName" runat="server" /><br />

                <asp:Label Text="Date of Birth:" runat="server" />
                <asp:TextBox ID="txtChildDateOfBirth" runat="server" TextMode="Date" /><br />

                <asp:Label Text="Gender:" runat="server" />
                <asp:DropDownList ID="ddlGender" runat="server">
                    <asp:ListItem Value="Male">Male</asp:ListItem>
                    <asp:ListItem Value="Female">Female</asp:ListItem>
                </asp:DropDownList><br />

                <asp:Label Text="Medical History:" runat="server" />
                <asp:TextBox ID="txtMedicalHistory" runat="server" TextMode="MultiLine" Rows="4" /><br />

                <asp:Label Text="Education Level:" runat="server" />
                <asp:TextBox ID="txtEducationLevel" runat="server" /><br />

                <asp:Label Text="Special Needs:" runat="server" />
                <asp:TextBox ID="txtSpecialNeeds" runat="server" TextMode="MultiLine" Rows="4" /><br />

                <asp:Label Text="Profile Image:" runat="server" />
                <asp:FileUpload ID="fuProfileImage" runat="server" /><br />

                <h4>Upload Documents</h4>
                <asp:Label Text="Document Type:" runat="server" />
                <asp:TextBox ID="txtDocumentType" runat="server" /><br />

                <asp:Label Text="Document Name:" runat="server" />
                <asp:TextBox ID="txtDocumentName" runat="server" /><br />

                <asp:Label Text="Document File:" runat="server" />
                <asp:FileUpload ID="fuDocument" runat="server" /><br />

                <asp:Button ID="btnSaveChild" runat="server" Text="Save Child" OnClick="btnSaveChild_Click" /><br />
                <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
            </div>
        </div>
    </form>
</body>
</html>
