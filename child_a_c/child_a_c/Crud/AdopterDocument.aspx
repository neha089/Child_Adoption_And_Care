<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdopterDocument.aspx.cs" Inherits="child_a_c.Crud.AdopterDocument" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Adopter Documents</title>
  <style>
      body {
          font-family: Arial, sans-serif;
          margin: 20px;
      }
      h2 {
          color: #333;
      }
      label {
          display: block;
          margin: 10px 0 5px;
      }
      input[type="text"], input[type="file"], input[type="date"] {
          width: 100%;
          padding: 8px;
          margin-bottom: 10px;
      }
      input[type="submit"] {
          background-color: #4CAF50;
          color: white;
          padding: 10px 15px;
          border: none;
          cursor: pointer;
      }
      input[type="submit"]:hover {
          background-color: #45a049;
      }
      .message {
          color: green;
          margin-top: 20px;
      }
  </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Manage Adopter Documents</h2>
       
        <asp:Label Text="Adopter ID:" runat="server" />
        <asp:TextBox ID="txtAdopterID" runat="server" /><br />

        <asp:Label Text="Document Type:" runat="server" />
        <asp:TextBox ID="txtDocumentType" runat="server" /><br />

        <asp:Label Text="Document Name:" runat="server" />
        <asp:TextBox ID="txtDocumentName" runat="server" /><br />

        <asp:Label Text="Upload Document:" runat="server" />
        <asp:FileUpload ID="fileUploadDocument" runat="server" /><br />

        <asp:Label Text="Upload Date:" runat="server" />
        <asp:TextBox ID="txtUploadDate" runat="server" TextMode="Date" /><br />

        <asp:Button ID="btnSave" runat="server" Text="Upload" OnClick="btnSave_Click" />
        
        <asp:Label ID="lblMessage" runat="server" CssClass="message" />
    </form>
</body>
</html>
