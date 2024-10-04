<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomeStudies.aspx.cs" Inherits="Crud.HomeStudies" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Studies</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
        }

        h3 {
            text-align: center;
            color: #333;
            margin-bottom: 20px;
        }

        form {
            background: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            max-width: 600px;
            margin: auto;
        }

        label {
            display: block;
            margin: 10px 0 5px;
            font-weight: bold;
            color: #555;
        }

        input[type="text"],
        input[type="date"],
        input[type="file"] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            margin-bottom: 15px;
            transition: border-color 0.3s;
        }

        input[type="text"]:focus,
        input[type="date"]:focus {
            border-color: #5b9bd5;
            outline: none;
        }

        button {
            background-color: #5b9bd5;
            color: white;
            padding: 10px 15px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s;
            width: 100%;
        }

        button:hover {
            background-color: #4a8cb8;
        }

        #lblMessage {
            text-align: center;
            margin-top: 10px;
        }

        .hidden {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <h3>Home Study Details</h3>
        
        <asp:Label Text="Adopter ID:" runat="server" />
        <asp:TextBox ID="txtAdopterID" runat="server" ReadOnly="true" /><br />

        <asp:Label Text="Child ID:" runat="server" />
        <asp:TextBox ID="txtChildID" runat="server" ReadOnly="true" /><br />

        <asp:Label Text="Orphanage ID:" runat="server" />
        <asp:TextBox ID="txtOrphanageID" runat="server" ReadOnly="true" /><br />

        <asp:Label Text="Date of Study:" runat="server" />
        <asp:TextBox ID="txtDateOfStudy" runat="server" TextMode="Date"/><br />

        <asp:Label Text="Home Study Report URL:" runat="server" />
        <asp:FileUpload ID="fuHomeStudyReport" runat="server" CssClass="file-upload" />
        <asp:Button ID="btnView" runat="server" Text="View Document" Visible="false" CssClass="btn-view" /><br />

        <asp:Label Text="Status:" runat="server" />
        <asp:TextBox ID="txtStatus" runat="server" /><br />

        <asp:Label Text="Comment:" runat="server" />
        <asp:TextBox ID="txtComment" runat="server" /><br />

        <asp:Label Text="Social Worker Name:" runat="server" />
        <asp:TextBox ID="txtSocialWorkerName" runat="server" /><br />

        <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Visible="false"></asp:Label>
        <asp:Button ID="btnback" runat="server" Text="Back" OnClick="btnBack_Click" />
    </form>
</body>
</html>
