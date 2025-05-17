<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userhomepage.aspx.cs" Inherits="E_commerce.userhomepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShopZone - Homepage</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- Custom CSS -->
    <link href="css/style.css" rel="stylesheet" />

    <!-- Bootstrap CSS & JS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

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
                            <a class="nav-link text-white" href="#">Cart</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-white" href="sign_out.aspx">Sign-Out</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        
       



    </form>
</body>
</html>
