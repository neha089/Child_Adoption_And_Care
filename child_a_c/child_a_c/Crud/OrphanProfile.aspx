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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="profile-container">
            <h2>Orphanage Profile</h2>
            <div class="profile-detail">
                <label>Name:</label> <asp:Label ID="lblName" runat="server" />
            </div>
            <div class="profile-detail">
                <label>Address:</label> <asp:Label ID="lblAddress" runat="server" />
            </div>
            <div class="profile-detail">
                <label>Phone Number:</label> <asp:Label ID="lblPhoneNumber" runat="server" />
            </div>
            <div class="profile-detail">
                <label>Email:</label> <asp:Label ID="lblEmail" runat="server" />
            </div>
            <div class="profile-detail">
                <label>Contact Person:</label> <asp:Label ID="lblContactPerson" runat="server" />
            </div>
            <div class="profile-detail">
                <label>Capacity:</label> <asp:Label ID="lblCapacity" runat="server" />
            </div>
            <div class="profile-detail">
                <label>Number of Children:</label> <asp:Label ID="lblNumberOfChildren" runat="server" />
            </div>
            <div class="profile-detail">
                <label>License Number:</label> <asp:Label ID="lblLicenseNumber" runat="server" />
            </div>

            <h3>Uploaded Documents</h3>
            <asp:Repeater ID="rptDocuments" runat="server">
                <ItemTemplate>
                    <div class="profile-detail">
                        <label>Document Name:</label>
                        <a href='<%# Eval("DocumentUrl") %>' target='_blank'><%# Eval("DocumentName") %></a>
                        <asp:Button ID="btnRemove" runat="server" CommandName="Remove" CommandArgument='<%# Eval("DocumentId") %>' Text="Remove" OnCommand="btnRemove_Command" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <h3>Upload New Document</h3>
            <div class="profile-detail">
                <label>Document Type:</label>
                <asp:TextBox ID="txtDocumentType" runat="server" />
            </div>
            <div class="profile-detail">
                <label>Document Name:</label>
                <asp:TextBox ID="txtDocumentName" runat="server" />
            </div>
            <div class="profile-detail">
                <label>Upload Document:</label>
                <asp:FileUpload ID="fuDocumentUpload" runat="server" />
            </div>
            <asp:Button ID="btnUpload" runat="server" Text="Upload Document" OnClick="btnUpload_Click" />

            <asp:Label ID="lblErrorMessage" runat="server" Visible="false" ForeColor="Red" />
                      <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="submit-button" OnClick="btnBack_Click" />

        </div>

    </form>
</body>
</html>
