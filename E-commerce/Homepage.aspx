<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="E_commerce.Homepage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShopZone - Homepage</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- Custom CSS -->
    <link href="css/style.css" rel="stylesheet" />
    <script
        src="https://code.jquery.com/jquery-3.7.1.js"
        integrity="sha256-eKhayi8LEQwp4NKxN+CfCh+3qOVUtJn3QNZ0TciWLP4="
        crossorigin="anonymous"></script>
    <!-- Bootstrap CSS & JS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <script>
        $(document).ready(function myfunction() {
            $("#btncart").click(function myfuction() {
                window.location="cart.aspx"
            });
        });
    </script>
     <style>
    .card-img-top {
        width: 100%;
        height: 15rem; 
        object-fit: cover;
    }
</style>

</head>
<body>
    <form id="form1" runat="server">


        <!-- Navbar -->
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary sticky-top px-4">
            <div class="container-fluid">
                <a class="navbar-brand fw-bold" href="#">ShopZone</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown"
                    aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse justify-content-end" id="navbarNavDropdown">
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link active text-warning" aria-current="page" href="Homepage.aspx">Home</a>
                        </li>

                        <!-- Products Dropdown with Submenu -->
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle text-white" href="#" id="productsDropdown" role="button"
                                data-bs-toggle="dropdown" aria-expanded="false">Products
                            </a>
                            <ul class="dropdown-menu" aria-labelledby="productsDropdown">

                                <!-- Men Category -->
                                <li class="dropdown-submenu">
                                    <a class="dropdown-item " href="#">Men</a>
                                   
                                </li>

                                <!-- Women Category -->
                                <li class="dropdown-submenu">
                                    <a class="dropdown-item " href="#">Women</a>
                                   
                                </li>

                            </ul>
                        </li>

                       
                        <li class="nav-item" id="btnsignin">
                            <a class="nav-link text-white" href="sign_in.aspx">Sign-In</a>
                        </li>
                        <li class="nav-item" id="btnsignup">
                            <a class="nav-link text-white" href="sign_up.aspx">Sign-Up</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>


        <!-- Carousel Slider -->
        <div id="carouselExampleCaptions" class="carousel slide animate-on-load" data-bs-ride="carousel" data-bs-interval="3000">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="images/slide1.jpg" class="d-block w-100" alt="Slide 1" />
                    <div class="carousel-caption">
                        <h1>Welcome to ShopZone</h1>
                        <p>Your favorite online store!</p>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="images/slide2.jpg" class="d-block w-100" alt="Slide 2" />
                    <div class="carousel-caption">
                        <h5>Redmi A4 5G</h5>
                        <p>Starting 6,499</p>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="images/slide3.jpg" class="d-block w-100" alt="Slide 3" />
                    <div class="carousel-caption">
                        <h5>Toys And Games</h5>
                        <p>Under 499 And 5% CashBank</p>
                    </div>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
        <hr />
        <%-- end slider --%>


        <div class="container my-5 animate-on-load">
    <div class="row g-4">
        <asp:Repeater ID="rp1" runat="server">
            <ItemTemplate>

                <div class="col-md-4">
                    <a href="sign_in.aspx" style="text-decoration:none; color:black">

                    <div class="card h-100">

                        <img src='<%# ResolveUrl("img/productimg/"+Eval("pid")+"/"+Eval("imgname").ToString().Trim()+Eval("extension").ToString().Trim()) %>'
                            class="card-img-top card-img"
                            alt='<%# Eval("imgname").ToString().Trim() %>' />
                      
                        <!-- Card Body -->
                        <div class="card-body">
                            <!-- Brand Name -->
                            <h6 class="text-muted"><%# Eval("name") %></h6>
                            <!-- Product Name -->
                            <h5 class="card-title"><%# Eval("pname") %></h5>
                            <!-- Product Description -->
                            <p class="card-text"><%# Eval("pdescription") %></p>
                            <!-- Prices -->
                            <div class="d-flex justify-content-between   align-items-center mb-3">
                                <span class="fw-bold text-danger"><%# Eval("price", "{0:0,00}") %></span>
                                <span class="text-success text-decoration-line-through">(<%# Eval("DiscAmount", "{0:c}") %>off)</span>
                                <span class="text-success text-decoration-through"><%# Eval("PSelPrice", "{0:c}") %></span>
                            </div>
                            <!-- Buy Now Button -->
                            
                        </div>
                    </div>
                          </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>



        <!-- Footer -->
        <footer class="bg-dark text-white text-center py-3 mt-5">
            &copy; 2025 ShopZone. All rights reserved.
        </footer>
    </form>
</body>
</html>
