<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplicationRecords.aspx.cs" Inherits="child_a_c.Crud.ApplicationRecords" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Application Records</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }
        h2 {
            color: #333;
        }
        label {
            font-weight: bold;
        }
        .form-control {
            margin-bottom: 10px;
        }
        .form-control input {
            padding: 5px;
            width: 300px;
        }
        .form-control button {
            padding: 10px 15px;
            background-color: #007BFF;
            color: white;
            border: none;
            cursor: pointer;
        }
        .form-control button:hover {
            background-color: #0056b3;
        }
        #lblMessage {
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Manage Application Records</h2>
            <div class="form-control">
                <asp:Label Text="Adopter ID:" runat="server" />
                <asp:TextBox ID="txtAdopterID" runat="server" />
            </div>
            <div class="form-control">
                <asp:Label Text="Orphanage ID:" runat="server" />
                <asp:TextBox ID="txtOrphanageID" runat="server" />
            </div>
            <div class="form-control">
                <asp:Label Text="Child ID:" runat="server" />
                <asp:TextBox ID="txtChildID" runat="server" />
            </div>
            <div class="form-control">
                <asp:Label Text="Application Date:" runat="server" />
                <asp:TextBox ID="txtApplicationDate" runat="server" TextMode="Date" />
            </div>
            <div class="form-control">
                <asp:Label Text="Status:" runat="server" />
                <asp:TextBox ID="txtStatus" runat="server" />
            </div>
            <div class="form-control">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </div>
            <div class="form-control">
                <asp:Label ID="lblMessage" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
