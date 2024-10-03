<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAdopterDocs.aspx.cs" Inherits="child_a_c.Crud.ViewAdopterDocs" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Documents</title>
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
        }

        .container {
            max-width: 800px;
            margin: auto;
            background: white;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
        }

        .document-list {
            list-style-type: none;
            padding: 0;
            margin-top: 20px;
        }

        .document-item {
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 10px;
            border-bottom: 1px solid #ddd;
        }

        .document-item a {
            text-decoration: none;
            color: white;
            font-weight: bold;
        }

        .btn-view {
            background-color: deepskyblue;
            padding: 5px 10px;
            text-decoration: none;
            border-radius: 4px;
            transition: background-color 0.3s;
        }

        .btn-view:hover {
            background-color: #0056b3;
        }

        .no-docs {
            color: #555;
            text-align: center;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Uploaded Documents</h2>
            <asp:Label ID="lblErrorMessage" runat="server" Visible="false" ForeColor="Red" />
            <ul class="document-list" id="ltrDocuments" runat="server"></ul>
            <asp:Literal ID="ltrNoDocs" runat="server" Visible="false"></asp:Literal>
          <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="submit-button" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>
