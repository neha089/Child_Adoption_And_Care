<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Signup" %>

<!DOCTYPE html>
<html>
<head>
    <title>Sign Up</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Sign Up</h2>
        <label>Select Type:</label>
        <asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
            <asp:ListItem Text="Select" Value=""></asp:ListItem>
            <asp:ListItem Text="Adopter" Value="Adopter"></asp:ListItem>
            <asp:ListItem Text="Orphanage" Value="Orphanage"></asp:ListItem>
            <asp:ListItem Text="Donor" Value="Donor"></asp:ListItem>
        </asp:DropDownList>

        <!-- Adopter Form -->
        <div id="adopterForm" runat="server" visible="false">
            <h3>Adopter Information</h3>
            <label>First Name:</label>
            <asp:TextBox ID="txtFirstName" runat="server" /><br />
            <label>Last Name:</label>
            <asp:TextBox ID="txtLastName" runat="server" /><br />
            <label>Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /><br />
            <label>Date of Birth:</label>
            <asp:TextBox ID="txtDateOfBirth" runat="server" /><br />
            <label>Address:</label>
            <asp:TextBox ID="txtAddress" runat="server" /><br />
            <label>Phone Number:</label>
            <asp:TextBox ID="txtPhoneNumber" runat="server" /><br />
            <label>Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" /><br />
            <label>Marital Status:</label>
            <asp:TextBox ID="txtMaritalStatus" runat="server" /><br />
            <label>Occupation:</label>
            <asp:TextBox ID="txtOccupation" runat="server" /><br />
            <label>Education Level:</label>
            <asp:TextBox ID="txtEducationLevel" runat="server" /><br />
        </div>

        <!-- Orphanage Form -->
        <div id="orphanageForm" runat="server" visible="false">
            <h3>Orphanage Information</h3>
            <label>Orphanage Name:</label>
            <asp:TextBox ID="txtOrphanageName" runat="server" /><br />
            <label>Address:</label>
            <asp:TextBox ID="txtOrphanageAddress" runat="server" /><br />
            <label>Phone Number:</label>
            <asp:TextBox ID="txtOrphanagePhoneNumber" runat="server" /><br />
            <label>Email:</label>
            <asp:TextBox ID="txtOrphanageEmail" runat="server" /><br />
            <label>Contact Person:</label>
            <asp:TextBox ID="txtContactPerson" runat="server" /><br />
            <label>Capacity:</label>
            <asp:TextBox ID="txtCapacity" runat="server" /><br />
            <label>Number of Children:</label>
            <asp:TextBox ID="txtNumChildren" runat="server" /><br />
            <label>License Number:</label>
            <asp:TextBox ID="txtLicenseNumber" runat="server" /><br />
            <label>Password:</label>
            <asp:TextBox ID="txtOrphanagePassword" runat="server" TextMode="Password" /><br />
           <p><label>Upload License:</label><asp:FileUpload ID="fuLicence" runat="server" CssClass="file-upload" /></p>
            <p><label>Upload ID Proof:</label><asp:FileUpload ID="fuIdProof" runat="server" CssClass="file-upload" /></p>
       </div>

        <!-- Donor Form -->
        <div id="donorForm" runat="server" visible="false">
            <h3>Donor Information</h3>
            <label>Donor Name:</label>
            <asp:TextBox ID="txtDonorName" runat="server" /><br />
            <label>Phone Number:</label>
            <asp:TextBox ID="txtDonorPhone" runat="server" /><br />
            <label>Email:</label>
            <asp:TextBox ID="txtDonorEmail" runat="server" /><br />
            <label>Password:</label>
            <asp:TextBox ID="txtDonorPassword" runat="server" TextMode="Password" /><br />
        </div>

        <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_Click" />
    </form>
</body>
</html>
