<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeStudies.aspx.cs" Inherits="child_a_c.Crud.HomeStudies" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Home Studies</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Manage Home Studies</h2>
        <asp:GridView ID="gvHomeStudies" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvHomeStudies_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="home_study_id" HeaderText="Home Study ID" />
                <asp:BoundField DataField="adopter_id" HeaderText="Adopter ID" />
                <asp:BoundField DataField="child_id" HeaderText="Child ID" />
                <asp:BoundField DataField="date_of_study" HeaderText="Date of Study" />
                <asp:BoundField DataField="home_study_report_url" HeaderText="Report URL" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:BoundField DataField="social_worker_name" HeaderText="Social Worker Name" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>

        <!-- Home Study Details -->
        <h3>Home Study Details</h3>
        <asp:Label Text="Home Study ID:" runat="server" />
        <asp:TextBox ID="txtHomeStudyID" runat="server" ReadOnly="true" /><br />

        <asp:Label Text="Adopter ID:" runat="server" />
        <asp:TextBox ID="txtAdopterID" runat="server" /><br />

        <asp:Label Text="Child ID:" runat="server" />
        <asp:TextBox ID="txtChildID" runat="server" /><br />

        <asp:Label Text="Date of Study:" runat="server" />
        <asp:TextBox ID="txtDateOfStudy" runat="server" /><br />

        <asp:Label Text="Home Study Report URL:" runat="server" />
        <asp:TextBox ID="txtHomeStudyReportURL" runat="server" /><br />

        <asp:Label Text="Status:" runat="server" />
        <asp:TextBox ID="txtStatus" runat="server" /><br />

        <asp:Label Text="Social Worker Name:" runat="server" />
        <asp:TextBox ID="txtSocialWorkerName" runat="server" /><br />

        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    </form>
</body>
</html>