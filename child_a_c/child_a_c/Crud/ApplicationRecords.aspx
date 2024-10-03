<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplicationRecords.aspx.cs" Inherits="child_a_c.Crud.ApplicationRecords" %>  
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Application Records</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #e9ecef;
            margin: 0;
            padding: 20px;
        }

        h2 {
            color: #007bff;
            text-align: center;
            margin-bottom: 20px;
            font-size: 2em;
        }

        .form-container {
            background: #ffffff;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 2px 15px rgba(0, 0, 0, 0.1);
            max-width: 700px;
            margin: auto;
            border: 1px solid #007bff;
        }

        p {
            margin: 15px 0;
        }

        label {
            font-weight: bold;
            color: #495057;
        }

        .file-upload {
            margin-bottom: 10px;
        }

        .success-message {
            color: #28a745;
            font-weight: bold;
            margin-top: 20px;
            text-align: center;
        }

        input[type="text"],
        input[type="date"],
        input[type="file"] {
            width: calc(100% - 22px);
            padding: 10px;
            border: 1px solid #ced4da;
            border-radius: 5px;
            margin-bottom: 10px;
            font-size: 1em;
        }

        .submit-button {
            background: #007bff;
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            transition: background-color 0.3s, transform 0.2s;
            display: inline-block;
            margin-right: 10px;
            box-shadow: 0 2px 5px rgba(0, 123, 255, 0.5);
        }

        .submit-button:hover {
            background: #0056b3;
            transform: scale(1.05);
        }

        .submit-button:active {
            background: #004085;
            box-shadow: 0 1px 3px rgba(0, 0, 0, 0.3);
        }

        .back-button {
            background: #6c757d;
        }

        .back-button:hover {
            background: #5a6268;
        }

        .back-button:active {
            background: #343a40;
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
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="back-button submit-button" OnClick="btnBack_Click" />

            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
