<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChildCrud.aspx.cs" Inherits="child_a_c.Crud.ChildCrud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Children Records</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f0f0;
            margin: 0;
            padding: 20px;
        }

        .container {
            max-width: 1200px;
            margin: auto;
        }

        .card, .child-card {
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            margin: 20px 0;
            padding: 20px;
            transition: transform 0.2s, box-shadow 0.2s;
            display: flex;
            align-items: center;
            justify-content: space-between;
        }

        .card:hover, .child-card:hover {
            transform: scale(1.02);
            box-shadow: 0 8px 16px rgba(0, 0, 0, 0.2);
        }

        h1 {
            text-align: center;
            color: #333;
            margin-bottom: 30px;
        }

        h4 {
            color: #333;
            margin: 0;
        }

        p {
            color: #666;
            margin: 5px 0;
        }

        img.profile-img {
            width: 100px;
            height: 100px;
            border-radius: 50%;
            object-fit: cover;
            margin-right: 20px;
        }

        /* Style for the edit form sidebar */
        #editForm {
            position: fixed;
            top: 100px;
            right: -600px; /* Start off-screen */
            width: 400px;
            height: 70%;
            background-color: #fff;
            border-left: 2px solid #ccc;
            box-shadow: -2px 0 10px rgba(0, 0, 0, 0.1);
            transition: right 0.3s ease; /* Transition for sliding effect */
            padding: 20px;
            z-index: 1000;
        }

        #editForm.show {
            right: 500px; /* Slide in */
        }

        @media (max-width: 768px) {
            .child-card {
                flex-direction: column;
                align-items: flex-start;
            }

            img.profile-img {
                margin-bottom: 15px;
            }
        }
         a,.btn-button{
     text-decoration: none;
     padding: 12px 20px;
     color: white;
     background-color: #007BFF;
     border-radius: 5px;
     transition: background-color 0.3s;
     display: inline-block;
     border: none;
     cursor: pointer;
 }

 a:hover,.btn-button:hover {
     background-color: #0056b3;
 }
    </style>
    <script>
        function openEditForm(firstName, lastName, dateOfBirth, gender, childId) {
            document.getElementById('txtFirstName').value = firstName;
            document.getElementById('txtLastName').value = lastName;
            document.getElementById('txtDateOfBirth').value = dateOfBirth;
            document.getElementById('ddlGender').value = gender;
            document.getElementById('<%= hfChildId.ClientID %>').value = childId;
            document.getElementById('editForm').classList.add('show');
        }

        function closeEditForm() {
            document.getElementById('editForm').classList.remove('show');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Children List</h1>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            <asp:Repeater ID="rptChildren" runat="server">
                <ItemTemplate>
                    <div class="child-card">
                        <div>
                            <img class="profile-img" src='<%# ResolveUrl(Eval("profile_image").ToString()) %>' alt="Profile Image" />
                        </div>
                        <div>
                            <h4><%# Eval("first_name") %> <%# Eval("last_name") %></h4>
                            <p>Date of Birth: <%# Eval("date_of_birth", "{0:MM/dd/yyyy}") %></p>
                            <p>Gender: <%# Eval("gender") %></p>
                        </div>
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn-button" CommandArgument='<%# Eval("child_id") %>' OnClientClick='<%# "openEditForm(\"" + Eval("first_name") + "\", \"" + Eval("last_name") + "\", \"" + Eval("date_of_birth") + "\", \"" + Eval("gender") + "\", \"" + Eval("child_id") + "\"); return false;" %>' />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <a href="AddChild.aspx">Add Child</a>
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn-button"/>

            <!-- Hidden form for editing -->
            <div id="editForm" runat="server">
                <h3>Edit Child Details</h3><br /><br />
                First Name:<asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name" /><br /><br />
                Last Name:<asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name" /><br /><br />
                D.O.B.:<asp:TextBox ID="txtDateOfBirth" runat="server" placeholder="Date of Birth" /><br /><br />
                Gender:<asp:DropDownList ID="ddlGender" runat="server">
                    <asp:ListItem Value="Male">Male</asp:ListItem>
                    <asp:ListItem Value="Female">Female</asp:ListItem>
                </asp:DropDownList><br /><br /><br />
                <asp:HiddenField ID="hfChildId" runat="server" />
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-button" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-button" OnClientClick="closeEditForm(); return false;" />
            </div>

            <asp:Label ID="Label1" runat="server" />
        </div>
    </form>
</body>
</html>
