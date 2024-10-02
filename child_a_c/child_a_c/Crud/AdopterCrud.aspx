<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdopterCrud.aspx.cs" Inherits="AdopterCrud" %> 
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Orphanages</title>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet" />
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

        .card {
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            margin: 20px 0;
            padding: 20px;
            cursor: pointer; 
        }

        h1 {
            text-align: center;
            color: #333;
        }

        .slideshow-container {
            position: relative;
            margin: auto;
            display: none; 
        }

        .mySlides {
            display: none;
        }

        .prev, .next {
            cursor: pointer;
            position: absolute;
            top: 50%;
            width: auto;
            padding: 16px;
            color: white;
            font-weight: bold;
            font-size: 18px;
            border-radius: 3px;
            user-select: none;
            background-color: rgba(0,0,0,0.6);
            transform: translateY(-50%);
        }

        .prev {
            left: 0; 
        }

        .next {
            right: 0; 
            margin-right:500px;
        }

        .prev:hover, .next:hover {
            background-color: rgba(0,0,0,0.8);
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

        .numbertext {
            color: #f2f2f2;
            font-size: 12px;
            padding: 8px 12px;
            position: absolute;
            top: 0;
        }

        .dot {
            cursor: pointer;
            height: 15px;
            width: 15px;
            margin: 0 2px;
            background-color: #bbb;
            border-radius: 50%;
            display: inline-block;
            transition: background-color 0.6s ease;
        }

        .active, .dot:hover {
            background-color: #717171;
        }

        .fade {
            animation-name: fade;
            animation-duration: 1.5s;
        }

        @keyframes fade {
            from {opacity: .4}
            to {opacity: 1}
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>List of Orphanages</h1>
            <asp:Repeater ID="rptOrphanages" runat="server">
                <ItemTemplate>
                    <div class="card" onclick="showSlideshow(this)">
                        <h3><%# Eval("name") %></h3>
                        <p><strong>Address:</strong> <%# Eval("address") %></p>
                        <p><strong>Phone:</strong> <%# Eval("phone_number") %></p>
                        <p><strong>Email:</strong> <%# Eval("email") %></p>
                        <asp:Button ID="btnSelectOrphanage" runat="server" Text="View Children" 
                                    CommandArgument='<%# Eval("orphanage_id") %>' OnCommand="btnSelectOrphanage_Command" />

                        <!-- Slideshow for Images -->
                        <div class="slideshow-container">
                            <asp:Repeater ID="rptImages" runat="server">
                                <ItemTemplate>
                                    <div class="mySlides fade">
                                        <img src='<%# Eval("image_url") %>' style="width:60%">
                                        <div class="text"><%# Eval("description") %></div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <a class="prev" onclick="plusSlides(-1)">&#10094;</a>
                            <a class="next" onclick="plusSlides(1)">&#10095;</a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>

    <script>
        function showSlides(slideshow) {
            let slides = slideshow.getElementsByClassName("mySlides");
            let slideIndex = 0; // Local slideIndex

            function displaySlides() {
                // Hide all slides
                for (let i = 0; i < slides.length; i++) {
                    slides[i].style.display = "none";
                }

                // Increment slide index
                slideIndex++;

                // Reset to the first slide if exceeded
                if (slideIndex > slides.length) {
                    slideIndex = 1;
                }

                // Display the current slide
                slides[slideIndex - 1].style.display = "block";

                // Change image every 2 seconds
                setTimeout(displaySlides, 2000);
            }

            displaySlides(); // Start the slideshow
        }

        function plusSlides(n) {
            // Handle manual slide control if needed
        }

        function showSlideshow(card) {
            let allSlideshows = document.querySelectorAll('.slideshow-container');

            // Hide all slideshows
            allSlideshows.forEach(slideshow => {
                slideshow.style.display = 'none';
            });

            // Show the selected slideshow
            let slideshow = card.querySelector('.slideshow-container');
            if (slideshow) {
                slideshow.style.display = 'block';
                showSlides(slideshow); // Pass the specific slideshow to the function
            }
        }
    </script>
</body>
</html>
