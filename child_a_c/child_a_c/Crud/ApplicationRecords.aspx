<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplicationRecords.aspx.cs" Inherits="child_a_c.Crud.ApplicationRecords" %>  
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Application Records</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
        }

        h2 {
            color: #333;
        }

        .form-container {
            background: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            max-width: 600px;
            margin: auto;
        }

        p {
            margin: 10px 0;
        }

        label {
            font-weight: bold;
        }

         .file-upload {
            margin-bottom: 10px;
        }

        .success-message {
            color: green;
            font-weight: bold;
            margin-top: 20px;
        }

        input[type="text"],
        input[type="date"] {
            width: calc(100% - 22px);
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            margin-bottom: 10px;
        }

        .submit-button {
            background: #28a745;
            color: white;
            border: none;
            padding: 10px 15px;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
        }

        .submit-button:hover {
            background: #218838;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <div class="form-container">
            <h2>Adoption Application</h2>
            <p><label>Orphanage ID:</label><asp:TextBox ID="lblOrphanageId" runat="server" ReadOnly /></p>
            <p><label>Child ID:</label><asp:TextBox ID="lblChildId" runat="server" ReadOnly="true" /></p>
            <p><label>Application Date:</label><asp:TextBox ID="txtApplicationDate" runat="server" ReadOnly="true" /></p>
            <p><label>Adopter Name:</label><asp:TextBox ID="lblAdopterName" runat="server" ReadOnly="true" /></p>
            <p><label>Adopter Email:</label><asp:TextBox ID="lblAdopterEmail" runat="server" ReadOnly="true" /></p>
            <p><label>Adopter Phone:</label><asp:TextBox ID="lblAdopterPhone" runat="server" ReadOnly="true" /></p>


            <p><label>Upload Personal Image:</label><asp:FileUpload ID="fuPersonalImage" runat="server" CssClass="file-upload" /></p>
            <p><label>Upload ID Proof:</label><asp:FileUpload ID="fuIdProof" runat="server" CssClass="file-upload" /></p>
            <p><label>Upload Birth Certificate:</label><asp:FileUpload ID="fuBirthCertificate" runat="server" CssClass="file-upload" /></p>
            <p><label>Upload Income Certificate:</label><asp:FileUpload ID="fuIncomeCertificate" runat="server" CssClass="file-upload" /></p>
            <p><label>Upload Caste Certificate:</label><asp:FileUpload ID="fuCasteCertificate" runat="server" CssClass="file-upload" /></p>

            <asp:Button ID="btnSubmit" runat="server" Text="Submit Application" CssClass="submit-button" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="submit-button" OnClick="btnBack_Click" />

            <asp:Label ID="lblSuccessMessage" runat="server" CssClass="success-message" Visible="false" />
        </div>
    </form>
</body>
</html>
