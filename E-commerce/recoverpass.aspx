<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recoverpass.aspx.cs" Inherits="E_commerce.recoverpass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <!-- Custom CSS -->
    <link href="css/style.css" rel="stylesheet" />

    <!-- Bootstrap CSS & JS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
       <div class="container d-flex align-items-center justify-content-center min-vh-100">
            <div class="card shadow p-4 fade-in" style="max-width: 400px; width: 100%;">
                <h3 class="text-center mb-4">Reset Password</h3>

                <div class="mb-3">
                    <label for="txtNewPassword" class="form-label">New Password</label>
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label for="txtConfirmPassword" class="form-label">Confirm Password</label>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" />
                </div>

                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary w-100" OnClick="btnSubmit_Click"  />

                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger mt-3 d-block text-center"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
