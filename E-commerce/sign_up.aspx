<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sign_up.aspx.cs" Inherits="E_commerce.sign_up" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShopZone - Sign-up</title>
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
                            <a class="nav-link text-white" href="sign_in.aspx">Sign-In</a>
                        </li>
                        <li class="nav-item">
    <a class="nav-link text-warning active" href="sign_up.aspx">Sign-Up</a>
</li>
                    </ul>
                </div>
            </div>
        </nav>

        <%-- main form --%>

        <div class="container form-container animate-on-load">
            <h2 class="text-center mb-4">Sign Up</h2>

            <div class="mb-3">
                <label for="name" class="form-label">Username</label>
                <asp:TextBox ID="name" runat="server" CssClass="form-control" placeholder="Enter username" />
            </div>

            <div class="mb-3">
                <label for="pass" class="form-label">Password</label>
                <asp:TextBox ID="pass" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter password" />
            </div>

            <div class="mb-3">
                <label for="txtConfirmPassword" class="form-label">Confirm Password</label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Re-enter password" />
            </div>

            <div class="mb-3">
                <label for="email" class="form-label">Email</label>
                <asp:TextBox ID="email" runat="server" CssClass="form-control" TextMode="Email" placeholder="Enter email" />
            </div>

            <div class="mb-3">
                <label for="p_mo" class="form-label">Phone Number</label>
                <asp:TextBox ID="p_mo" runat="server" CssClass="form-control" placeholder="Enter phone number" />
            </div>

            <div class="mb-3">
                <label for="address" class="form-label">Address</label>
                <asp:TextBox ID="address" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" placeholder="Enter address" />
            </div>

            <div class="mb-3">
                <label class="form-label">Gender</label><br />
                <asp:RadioButton ID="rdoMale" runat="server" GroupName="Gender" Text=" Male" CssClass="form-check-input me-1" />
                <asp:RadioButton ID="rdoFemale" runat="server" GroupName="Gender" Text=" Female" CssClass="form-check-input ms-3 me-1" />
            </div>

            <div class="mb-3">
                <label for="img" class="form-label">Upload Image</label>
                <asp:FileUpload ID="img" runat="server" CssClass="form-control" />
            </div>

            <asp:Button ID="btn" runat="server" Text="Sign Up" CssClass="btn btn-primary w-100" OnClick="btn_Click" />

            <div class="mb-3 text-center">
                <br />
                <p>Already have an account?<a href="sign_in.aspx">Sign-In</a></p>
            </div>
        </div>


        <!-- Footer -->
        <footer class="bg-dark text-white text-center py-3 mt-5">
            &copy; 2025 ShopZone. All rights reserved.
        </footer>
    </form>
</body>
</html>
