<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChildrenList.aspx.cs" Inherits="ChildrenList" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Children List</title>
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

        h3, h4 {
            color: #333;
            margin: 0;
        }

        p {
            color: #666;
            margin: 5px 0;
        }


        button {
            background-color: #28a745;
            color: white;
            border: none;
            padding: 10px 15px;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.2s, transform 0.2s;
        }

        button:hover {
            background-color: #218838;
            transform: translateY(-2px);
        }

        /* Responsive Design */
        @media (max-width: 768px) {
            .child-card {
                flex-direction: column;
                align-items: flex-start;
            }

            img.profile-img {
                margin-bottom: 15px;
            }
        }
    </style>
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
                <h4><%# Eval("first_name") %> <%# Eval("last_name") %></h4>
                <p>Date of Birth: <%# Eval("date_of_birth", "{0:MM/dd/yyyy}") %></p>
                <p>Gender: <%# Eval("gender") %></p>
                <p>Status: <%# Eval("status") %></p>
                
                <!-- Use a literal control to display notes conditionally -->
                <asp:Literal ID="litNotes" runat="server" 
                             Text='<%# Eval("notes") != DBNull.Value ? Eval("notes") : "N/A" %>' />
            </div>
            <%-- The adopt button only appears if the status is DBNull --%>
            <asp:Button ID="btnAdopt" runat="server" Text="Adopt" 
                         CommandArgument='<%# Eval("child_id") + ";" + Eval("orphanage_id") %>' 
                         OnCommand="btnAdopt_Command" 
                         Visible='<%# Eval("status") == DBNull.Value %>' />
        </div>
        </ItemTemplate>
        </asp:Repeater>

        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="submit-button" OnClick="btnBack_Click" />
        </div>

    </form>
</body>
</html>
