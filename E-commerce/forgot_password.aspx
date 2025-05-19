<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgot_password.aspx.cs" Inherits="E_commerce.forgot_password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- Custom CSS -->
    <link href="css/style.css" rel="stylesheet" />

    <!-- Bootstrap CSS & JS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
         <nav class="navbar navbar-expand-lg navbar-dark bg-primary sticky-top px-4">
     <div class="container-fluid">
         <a class="navbar-brand fw-bold" href="Homepage.aspx">ShopZone</a>
         </div>
             </nav>
        
        <div class="container d-flex justify-content-center align-items-center vh-100 fade-in">
            <div class="card shadow p-4 rounded-4 w-100" style="max-width: 400px;">
                <h3 class="text-center mb-4">Forgot Password</h3>
                <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-info d-none" EnableViewState="false" />
                <div class="mb-3">
                    <asp:TextBox ID="email" runat="server" CssClass="form-control" placeholder="Enter your email" />
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="email"
                        CssClass="text-danger" ErrorMessage="Email is required." Display="Dynamic" />
                </div>
                <div class="d-grid">
                    <asp:Button ID="btnSend" runat="server" Text="Send Reset Link" CssClass="btn btn-primary" OnClick="btnSend_Click"  />
                </div>
                <div class="text-center mt-3">
                    <a href="sign_in.aspx" class="text-decoration-none">Back to Sign In</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
