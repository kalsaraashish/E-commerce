<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sign_in.aspx.cs" Inherits="E_commerce.sign_in" %>

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
                <div class="d-grid">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" />
                </div>
                <div class="text-center mt-3">
                    <p>Don't have an account?<a href="sign_up.aspx"> Sign up</a></p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
