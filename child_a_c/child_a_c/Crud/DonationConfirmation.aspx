<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DonationConfirmation.aspx.cs" Inherits="child_a_c.Crud.DonationConfirmation" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Donation Confirmation</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            padding: 20px;
        }
        .confirmation-box {
            background-color: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 400px;
            margin: auto;
            text-align: center;
        }
        .confirmation-box h2 {
            color: #28a745;
        }
        .donation-details {
            margin-top: 20px;
            text-align: left;
        }
        .donation-details label {
            font-weight: bold;
        }
        .donation-details p {
            margin: 5px 0;
        }
        .btn-home {
            margin-top: 20px;
            padding: 10px 20px;
            background-color: #007bff;
            color: white;
            text-decoration: none;
            border-radius: 5px;
        }
        .btn-home:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="confirmation-box">
            <h2>Thank You for Your Donation!</h2>
            <p>Your contribution is greatly appreciated. </p>
        </div>
    </form>
</body>
</html>
