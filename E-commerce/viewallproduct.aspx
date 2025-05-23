<%@ Page Title="" Language="C#" MasterPageFile="~/usertemplate.Master" AutoEventWireup="true" CodeBehind="viewallproduct.aspx.cs" Inherits="E_commerce.viewallproduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="container my-5 animate-on-load">
        <asp:Repeater ID="rp1" runat="server">
            <ItemTemplate>
        <div class="row g-4">
            <div class="col-md-4">
                <div class="card h-100">
                    <img src="img/productimg/<%# Eval("pid") %>/<%# Eval("name") %><%# Eval("extension") %>" class="card-img-top card-img" alt="Product 1">
                    <div class="card-body">
                        <h5 class="card-title">Product Title</h5>
                        <p class="card-text">Short description of the product.</p>
                        <%--<div class="mb-2">⭐⭐⭐⭐☆</div>--%>
                        <p class="card-text fw-bold">$49.99</p>
                        <a href="#" class="btn btn-primary">Buy Now</a>
                    </div>
                </div>
            </div>
        </div>
                </ItemTemplate>
            </asp:Repeater>
    </div>



</asp:Content>
