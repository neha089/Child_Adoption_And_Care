<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplicationRecords.aspx.cs" Inherits="child_a_c.Crud.ApplicationRecords" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Application Records</title>
    <style>
        body {
            font-family: Arial, sans-serif;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Manage Application Records</h2>
            <asp:GridView ID="gvApplicationRecords" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvApplicationRecords_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="application_id" HeaderText="Application ID" />
                    <asp:BoundField DataField="adopter_id" HeaderText="Adopter ID" />
                    <asp:BoundField DataField="orphanage_id" HeaderText="Orphanage ID" />
                    <asp:BoundField DataField="child_id" HeaderText="Child ID" />
                    <asp:BoundField DataField="application_date" HeaderText="Application Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="status" HeaderText="Status" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>

            <h3>Application Details</h3>
            <div class="form-control">
                <asp:Label Text="Application ID:" runat="server" />
                <asp:TextBox ID="txtApplicationID" runat="server" ReadOnly="true" />
            </div>
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
                <asp:TextBox ID="txtApplicationDate" runat="server" />
            </div>
            <div class="form-control">
                <asp:Label Text="Status:" runat="server" />
                <asp:TextBox ID="txtStatus" runat="server" />
            </div>
            <div class="form-control">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </div>
        </div>
    </form>
</body>
</html>
