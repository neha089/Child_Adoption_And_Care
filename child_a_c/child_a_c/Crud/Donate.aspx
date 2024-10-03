<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Donate.aspx.cs" Inherits="child_a_c.Crud.Donate" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Donate</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            padding: 20px;
        }
        .donation-form {
            background-color: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 400px;
            margin: auto;
        }
        .donation-form h2 {
            text-align: center;
            color: #333;
        }
        .form-group {
            margin-bottom: 15px;
        }
        .form-group label {
            display: block;
            margin-bottom: 5px;
        }
        .form-group input,
        .form-group select {
            width: 100%;
            padding: 10px;
            border-radius: 5px;
            border: 1px solid #ccc;
        }
        .btn-submit {
            background-color: #28a745;
            color: white;
            padding: 10px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            width: 100%;
        }
        .btn-submit:hover {
            background-color: #218838;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="donation-form">
            <h2>Donation Form</h2>
            <!-- Donor Name -->
            <div class="form-group">
                <label for="txtDonorName">Donor Name</label>
                <asp:TextBox ID="txtDonorName" runat="server"></asp:TextBox>
            </div>
            <!-- Orphanage Name -->
            <div class="form-group">
                <label for="txtOrphanageName">Orphanage Name</label>
                <asp:TextBox ID="txtOrphanageName" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
            <!-- Donation Amount -->
            <div class="form-group">
                <label for="txtAmount">Donation Amount</label>
                <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
            </div>
            <!-- Donation Type -->
            <div class="form-group">
                <label for="ddlDonationType">Donation Type</label>
                <asp:DropDownList ID="ddlDonationType" runat="server">
                    <asp:ListItem Value="Cash" Text="Cash"></asp:ListItem>
                    <asp:ListItem Value="Goods" Text="Goods"></asp:ListItem>
                    <asp:ListItem Value="Services" Text="Services"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <!-- Donation Date -->
            <div class="form-group">
                <label for="txtDate">Donation Date</label>
                <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <!-- Purpose -->
            <div class="form-group">
                <label for="txtPurpose">Purpose</label>
                <asp:TextBox ID="txtPurpose" runat="server"></asp:TextBox>
            </div>
            <!-- Receipt URL -->
            <div class="form-group">
                <label for="txtReceiptUrl">Receipt URL</label>
                <asp:TextBox ID="txtReceiptUrl" runat="server"></asp:TextBox>
            </div>
            
            <!-- Submit Button -->
            <asp:Button ID="btnSubmit" runat="server" Text="Submit Donation" CssClass="btn-submit" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>
