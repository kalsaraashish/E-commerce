<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sign_in.aspx.cs" Inherits="E_commerce.sign_in" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShopZone - Sign-in</title>
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
                <a class="navbar-brand fw-bold" href="Homepage.aspx">ShopZone</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavDropdown"
                    aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse justify-content-end" id="navbarNavDropdown">
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link active" aria-current="page" href="Homepage.aspx">Home</a>
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
                            <a class="nav-link  active text-warning" href="sign_in.aspx">Sign-In</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link text-white " href="sign_up.aspx">Sign-Up</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>



        <div class="container d-flex justify-content-center align-items-center vh-100 fade-in">
            <div class="card shadow p-4 rounded-4" style="width: 100%; max-width: 400px;">
                <h2 class="text-center mb-4">Sign In</h2>
                <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-danger d-none" EnableViewState="false" />
                <div class="mb-3">
                    <asp:TextBox ID="username" runat="server" CssClass="form-control" placeholder="Username" />
                    <asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="username" CssClass="text-danger" ErrorMessage="Enter valid Username"></asp:RequiredFieldValidator>
                </div>
                <div class="mb-3">
                    <asp:TextBox ID="pass" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password" />
                    <asp:RequiredFieldValidator ID="r2" runat="server" ControlToValidate="pass" CssClass="text-danger" ErrorMessage="Enter valid Password"></asp:RequiredFieldValidator>
                </div>

                <div class="d-flex justify-content-between align-items-center mb-3">
                    <div class="form-check">
                        <asp:CheckBox ID="chkRememberMe" runat="server" CssClass="form-check-input" />
                        <label class="form-check-label" for="chkRememberMe">Remember me</label>
                    </div>
                   <asp:HyperLink ID="lnkForgotPassword" runat="server" NavigateUrl="~/forgot_password.aspx" CssClass="text-decoration-none">
        Forgot Password?
    </asp:HyperLink>
                </div>
                <div class="d-grid">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                </div>

                <div class="text-center mt-3">
                    <p>Don't have an account?<a href="sign_up.aspx"> Sign up</a></p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
