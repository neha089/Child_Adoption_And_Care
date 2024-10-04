<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrphanageDashboard.aspx.cs" Inherits="child_a_c.Crud.OrphanageDashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Orphanage Dashboard</title>
        <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet" />

    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
        }

        h2 {
            color: #333;
            text-align: center;
            margin-bottom: 10px;
        }

        h3 {
            color: #555;
            text-align: center;
            margin-bottom: 30px;
        }
        .profile-icon {
            position: absolute;
            top: 20px;
            right: 20px;
            font-size: 40px;
            color: #333;
            cursor: pointer;
            text-decoration: none;
        }

        .profile-icon:hover {
            color: #218838;
        }

        .container {
            max-width: 1000px;
            margin: auto;
            background: white;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            padding: 20px;
        }

        ul {
            list-style-type: none;
            padding: 0;
            margin: 0;
        }

        li {
            margin: 15px 0;
            text-align: left;
        }

        .logout-button ,.btn-button{
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

         .logout-button:hover,.btn-button:hover {
            background-color: #0056b3;
        }

        .logout-button {
            background-color: #dc3545;
        }

        .logout-button:hover {
            background-color: #c82333;
        }

        footer {
            text-align: center;
            margin-top: 20px;
            font-size: 14px;
            color: #777;
        }

        .table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .table th, .table td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: center;
        }

        .table th {
            background-color: #007BFF;
            color: white;
        }

        .status-btn {
            margin-right: 5px;
            padding: 5px 10px;
            color: white;
            border: none;
            cursor: pointer;
        }

        .accepted {
            background-color: #28a745;
        }

        .rejected {
            background-color: #dc3545;
        }

        .btn {
            background-color: #007BFF;
        }
        .slideshow-container {
            position: relative;
            margin: auto;
            display: block; 
            height:400px;
            width:600px;
        }

        .mySlides {
            display: none;
        }

        .prev, .next {
            cursor: pointer;
            position: absolute;
            top: 50%;
            padding: 16px;
            color: white;
            font-weight: bold;
            font-size: 18px;
            background-color: rgba(0, 0, 0, 0.6);
            border-radius: 3px;
            transform: translateY(-50%);
        }

        .prev {
            left: 0;
        }

        .next {
            right: 0;
        }

        .prev:hover, .next:hover {
            background-color: rgba(0, 0, 0, 0.8);
        }

        .text {
            color: #f2f2f2;
            font-size: 15px;
            padding: 8px 12px;
            position: absolute;
            bottom: 8px;
            width: 100%;
            text-align: center;
        }

        .fade {
            animation-name: fade;
            animation-duration: 1.5s;
        }

        @keyframes fade {
            from { opacity: 0.4; }
            to { opacity: 1; }
        }
    </style>
    <script>
        let slideIndex = 0;

        function showSlides() {
            let slides = document.getElementsByClassName("mySlides");
            for (let i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            slideIndex++;
            if (slideIndex > slides.length) { slideIndex = 1 }
            slides[slideIndex - 1].style.display = "block";
            setTimeout(showSlides, 3000); // Change image every 3 seconds
        }

        function plusSlides(n) {
            slideIndex += n;
            showSlidesManually();
        }

        function showSlidesManually() {
            let slides = document.getElementsByClassName("mySlides");
            if (slideIndex > slides.length) { slideIndex = 1 }
            if (slideIndex < 1) { slideIndex = slides.length }
            for (let i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            slides[slideIndex - 1].style.display = "block";
        }
    </script>
</head>
<body onload="showSlides()">

    <form id="form1" runat="server" method="post">
        <asp:Label ID="lblTotalDonations" runat="server" style="text-align:center;   margin-left: 650px;
    font-weight: bold;"></asp:Label>

        <div class="top-right">
        <a href="OrphanProfile.aspx" class="profile-icon" title="Profile">
          <i class="fas fa-user-circle"></i>
         </a>
                    <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="logout-button" />

        </div>
        <div class="container">
            <h2>Orphanage Dashboard</h2>
            <h3>Welcome, <%= Session["OrphanageName"] ?? "Orphanage" %>!</h3>

              <div class="slideshow-container">
      <asp:Repeater ID="rptOrphanageImages" runat="server">
          <ItemTemplate>
              <div class="mySlides fade">
                  <img src='<%# Eval("image_url") %>' style="width:100%">
                  <div class="text"><%# Eval("description") %></div>
              </div>
          </ItemTemplate>
      </asp:Repeater>
      <a class="prev" onclick="plusSlides(-1)">&#10094;</a>
      <a class="next" onclick="plusSlides(1)">&#10095;</a>
  </div>

           <ul>
    <li><asp:Button ID="ViewChildren" runat="server" Text="View Children" CssClass="btn-button" OnClick="btnViewChildren" /></li>

    <li>
        <h2 style="text-align: left; margin-bottom: 10px;">Upload Image</h2>
        <asp:FileUpload ID="fileUploadControl" runat="server" />
    </li>
    <li>
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="3" placeholder="Enter image description..." style="width: 95%; padding: 10px; margin-top: 10px;"></asp:TextBox>
    </li>
    <li>
        <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn-button" onClick="btnUpload_Click"/>
    </li>
    <li>
        <asp:Label ID="lblUploadMessage" runat="server" Visible="false" style="color: green; font-weight: bold;"></asp:Label>
    </li>
    <li>
        <asp:Label ID="lblUploadError" runat="server" Visible="false" style="color: red; font-weight: bold;"></asp:Label>
    </li>
    <li>
        <asp:Label ID="lblSuccessMessage" runat="server" Visible="false" ForeColor="Green" />
    </li>
    <li>
        <asp:Label ID="lblErrorMessage" runat="server" Visible="false" ForeColor="Red" />
    </li>
</ul>
<br />
            <h2 style="text-align:left">Applied Adopters Details</h2>
            <asp:GridView ID="gvApplicationRecords" runat="server" AutoGenerateColumns="False" CssClass="table" OnRowCommand="OnRowCommand">
                <Columns>
                    <asp:BoundField DataField="application_id" HeaderText="Application ID" />
                    <asp:BoundField DataField="adopter_name" HeaderText="Adopter Name" />
                    <asp:BoundField DataField="child_id" HeaderText="Child ID" />
                    <asp:BoundField DataField="application_date" HeaderText="Application Date" />
                    <asp:BoundField DataField="status" HeaderText="Status" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnAccept" runat="server" CommandName="Accept" CommandArgument='<%# Eval("application_id") %>' CssClass="status-btn accepted" Text="Accept" />
                            <asp:Button ID="btnReject" runat="server" CommandName="Reject" CommandArgument='<%# Eval("application_id") %>' CssClass="status-btn rejected" Text="Reject" />
                            <asp:Button ID="btnViewDocuments" runat="server" CommandName="ViewDocuments" CommandArgument='<%# Eval("application_id") %>' CssClass="status-btn btn" Text="View Documents" />
                            <asp:Button ID="btnHomeStudy" runat="server" CommandName="HomeStudy" CommandArgument='<%# Eval("application_id") %>' CssClass="status-btn btn" Text="Home Study" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
    <footer>Orphanage Child Adoption Platform</footer>
     
</body>
</html>
