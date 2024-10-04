<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdoptionHistory.aspx.cs" Inherits="YourNamespace.AdoptionHistory" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Orphanage Adoption History</title>
    <style>
        /* Body Styling */
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f9;
            margin: 0;
            padding: 0;
        }

        /* Wrapper for the content */
        .container {
            width: 90%;
            margin: 20px auto;
        }

        /* Title styling */
        h2 {
            text-align: center;
            color: #333;
        }

        /* Card Layout for the Grid */
        .card {
            background-color: #fff;
            border: 1px solid #ddd;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            margin-bottom: 20px;
            padding: 20px;
            transition: transform 0.3s ease-in-out;
        }

        .card:hover {
            transform: scale(1.02);
        }

        .card h3 {
            font-size: 1.2em;
            margin: 0 0 10px;
            color: #333;
        }

        .card p {
            font-size: 0.9em;
            margin: 0;
            color: #555;
        }

        /* Styling the grid headers */
        .grid-header {
            background-color: #007bff;
            color: white;
            padding: 10px;
            border-radius: 8px 8px 0 0;
            text-align: left;
        }

        /* Custom label */
        .label {
            font-weight: bold;
        }

        /* Styling the footer */
        .footer {
            text-align: center;
            margin-top: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Adoption Records for Orphanage</h2>
            <asp:Label ID="lblOrphanageName" runat="server" Text=""></asp:Label>
            <br /><br />

            <!-- Loop through GridView rows and display them as cards -->
            <asp:Repeater ID="rptAdoptionRecords" runat="server">
                <HeaderTemplate>
                    <div class="grid-header">Adoption Records</div>
                </HeaderTemplate>

                <ItemTemplate>
                    <div class="card">
                        <h3>Adoption ID: <%# Eval("adoption_id") %></h3>
                        <p><span class="label">Adopter ID:</span> <%# Eval("adopter_id") %></p>
                        <p><span class="label">Child ID:</span> <%# Eval("child_id") %></p>
                        <p><span class="label">Adoption Date:</span> <%# Eval("adoption_date", "{0:dd/MM/yyyy}") %></p>
                        <p><span class="label">Finalization Date:</span> <%# Eval("finalization_date", "{0:dd/MM/yyyy}") %></p>
                        <p><span class="label">Status:</span> <%# Eval("adoption_status") %></p>
                        <p><span class="label">Documents:</span> <%# Eval("legal_documents") %></p>
                        <p><span class="label">Notes:</span> <%# Eval("notes") %></p>
                    </div>
                </ItemTemplate>

               <FooterTemplate>
    <div class="footer">Total Records: <%# TotalRecordCount %></div>
</FooterTemplate>

            </asp:Repeater>
        </div>
    </form>
</body>
</html>
