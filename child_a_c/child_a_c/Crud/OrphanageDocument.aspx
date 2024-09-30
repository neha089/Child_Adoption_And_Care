<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrphanageDocument.aspx.cs" Inherits="child_a_c.Crud.OrphanageDocument" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Orphanage Documents</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Manage Orphanage Documents</h2>
        <asp:GridView ID="gvOrphanageDocuments" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvOrphanageDocuments_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="document_id" HeaderText="Document ID" />
                <asp:BoundField DataField="orphanage_id" HeaderText="Orphanage ID" />
                <asp:BoundField DataField="document_type" HeaderText="Document Type" />
                <asp:BoundField DataField="document_name" HeaderText="Document Name" />
                <asp:BoundField DataField="document_url" HeaderText="Document URL" />
                <asp:BoundField DataField="upload_date" HeaderText="Upload Date" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>

        <!-- Document Details -->
        <h3>Document Details</h3>
        <asp:Label Text="Document ID:" runat="server" />
        <asp:TextBox ID="txtDocumentID" runat="server" ReadOnly="true" /><br />

        <asp:Label Text="Orphanage ID:" runat="server" />
        <asp:TextBox ID="txtOrphanageID" runat="server" /><br />

        <asp:Label Text="Document Type:" runat="server" />
        <asp:TextBox ID="txtDocumentType" runat="server" /><br />

        <asp:Label Text="Document Name:" runat="server" />
        <asp:TextBox ID="txtDocumentName" runat="server" /><br />

        <asp:Label Text="Document URL:" runat="server" />
        <asp:TextBox ID="txtDocumentURL" runat="server" /><br />

        <asp:Label Text="Upload Date:" runat="server" />
        <asp:TextBox ID="txtUploadDate" runat="server" /><br />

        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    </form>
</body>
</html>