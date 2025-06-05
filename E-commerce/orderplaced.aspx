<%@ Page Title="" Language="C#" MasterPageFile="~/usertemplate.Master" AutoEventWireup="true" CodeBehind="orderplaced.aspx.cs" Inherits="E_commerce.orderplaced" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-md-8 text-center">
                    <div class="alert alert-success shadow p-4 rounded">
                        <h2 class="mb-3">🎉 Order Placed Successfully!</h2>
                        <p class="lead">Thank you for your purchase. Below are your order details:</p>
                        <hr />
                        <div class="text-start mt-4">
                            <p><strong>Order ID:</strong> <asp:Label ID="lblOrderID" runat="server" CssClass="fw-bold text-success"></asp:Label></p>
                            <p><strong>Name:</strong> <asp:Label ID="lblName" runat="server" CssClass="fw-bold"></asp:Label></p>
                            <p><strong>Email:</strong> <asp:Label ID="lblEmail" runat="server" CssClass="fw-bold"></asp:Label></p>
                            <p><strong>Mobile:</strong> <asp:Label ID="lblMobile" runat="server" CssClass="fw-bold"></asp:Label></p>
                            <p><strong>Total Amount:</strong> ₹<asp:Label ID="lblTotal" runat="server" CssClass="fw-bold text-primary"></asp:Label></p>
                        </div>
                        <a href="userhomepage.aspx" class="btn btn-outline-primary mt-4">Continue Shopping</a>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
