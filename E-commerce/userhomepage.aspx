<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userhomepage.aspx.cs" Inherits="E_commerce.userhomepage" %>

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
                            <asp:Label runat="server" ID="username" Text="" class="nav-link active " aria-current="page"></asp:Label>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active text-warning" aria-current="page" href="userhomepage.aspx">Home</a>
                        </li>

                        <!-- Products Dropdown with Submenu -->
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle text-white" href="#" id="productsDropdown" role="button"
                                data-bs-toggle="dropdown" aria-expanded="false">Products
                            </a>
                            <ul class="dropdown-menu" aria-labelledby="productsDropdown">
                                <li class="dropdowm-submenu" >
                                    <a class="dropdown-item " href="viewallproduct.aspx">All Product</a>
                                </li>
                                <li role="separator" class="divider"></li>
                                <!-- Men Category -->
                                <li class="dropdown-submenu">
                                    <a class="dropdown-item dropdown-toggle" href="#">Men</a>
                                    <ul class="dropdown-menu">
                                        <li><a class="dropdown-item" href="#">Shirts</a></li>
                                        <li><a class="dropdown-item" href="#">Pants</a></li>
                                    </ul>
                                </li>

                                <!-- Women Category -->
                                <li class="dropdown-submenu">
                                    <a class="dropdown-item dropdown-toggle" href="#">Women</a>
                                    <ul class="dropdown-menu">
                                        <li><a class="dropdown-item" href="#">Tops</a></li>
                                        <li><a class="dropdown-item" href="#">Leggings</a></li>
                                        <li><a class="dropdown-item" href="#">Dresses</a></li>
                                    </ul>
                                </li>

                            </ul>
                        </li>

                        <li class="nav-item">
                            <%--<a class="nav-link text-white" href="#">Cart</a>--%>
                              <button id="btncart" class="nav-link text-white btn btn-primary" type="button">Cart<span class="badge" id="pcount" runat="server"></span></button>
                            <%--<a class="nav-link text-white" id="log_out" href="sign_out.aspx">Sign-Out</a>--%>
                            </li>
                        <li class="nav-item">
                            <asp:Button ID="btnlogout" CssClass="nav-link text-white btn btn-default navbar-btn " runat="server" Text="Sign Out" OnClick="btnlogout_Click"/>

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
                    <img src="images/slide1.jpg" class="d-block w-100" alt="Slide 1">
                    <div class="carousel-caption">
                        <h1>Welcome to ShopZone</h1>
                        <p>Your favorite online store!</p>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="images/slide2.jpg" class="d-block w-100" alt="Slide 2">
                    <div class="carousel-caption">
                        <h5>Redmi A4 5G</h5>
                        <p>Starting 6,499</p>
                    </div>
                </div>
                <div class="carousel-item">
                    <img src="images/slide3.jpg" class="d-block w-100" alt="Slide 3">
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

        <!-- Product Items Section -->
        <div class="container my-5 animate-on-load">
            <div class="row g-4">
                <div class="col-md-4">
                    <div class="card h-100">
                        <img src="images/i1.png" class="card-img-top card-img" alt="Product 1">
                        <div class="card-body">
                            <h5 class="card-title">Product Title</h5>
                            <p class="card-text">Short description of the product.</p>
                            <div class="mb-2">⭐⭐⭐⭐☆</div>
                            <p class="card-text fw-bold">$49.99</p>
                            <a href="#" class="btn btn-primary">Buy Now</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card h-100">
                        <img src="images/i2.jpg" class="card-img-top card-img" alt="Product 2">
                        <div class="card-body">
                            <h5 class="card-title">Another Product</h5>
                            <p class="card-text">Great quality item with discount.</p>
                            <div class="mb-2">⭐⭐⭐⭐⭐</div>
                            <p class="card-text fw-bold">$29.99</p>
                            <a href="#" class="btn btn-primary">Buy Now</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card h-100">
                        <img src="images/i1.png" class="card-img-top card-img" alt="Product 2">
                        <div class="card-body">
                            <h5 class="card-title">Another Product</h5>
                            <p class="card-text">Great quality item with discount.</p>
                            <div class="mb-2">⭐⭐⭐⭐⭐</div>
                            <p class="card-text fw-bold">$29.99</p>
                            <a href="#" class="btn btn-primary">Buy Now</a>
                        </div>
                    </div>
                </div>
                <!-- Add more cards as needed -->
            </div>
        </div>


    </form>
</body>
</html>
