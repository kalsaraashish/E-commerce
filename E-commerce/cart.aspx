<%@ Page Title="" Language="C#" MasterPageFile="~/usertemplate.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="E_commerce.cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .cart-item {
            border-bottom: 1px solid #dee2e6;
            padding: 15px 0;
        }

            .cart-item img {
                width: 100px;
                height: auto;
                object-fit: cover;
            }

        .price-detail {
            background-color: #f8f9fa;
            padding: 20px;
            border-radius: 10px;
        }

            .price-detail h5 {
                margin-bottom: 20px;
            }

        .remove-btn {
            color: red;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container py-4">
        <div class="row">
            <!-- Cart Items -->
            <div class="col-md-8">
                <h3 runat="server" id="h3noitems"> </h3>


                <asp:Repeater ID="rpcart" runat="server">

                    <ItemTemplate>
                        <!-- Sample Cart Item -->
                        <div class="cart-item d-flex align-items-center">
                            <%--<img src="https://via.placeholder.com/100" alt="Product Image" class="me-3" />--%>
                            <a href="viewproduct.aspx?pid=<%# Eval("pid") %>" target="_blank">
                                <img src='<%# ResolveUrl("img/productimg/" + Eval("pid") + "/" + Eval("imgname").ToString().Trim() + Eval("extension").ToString().Trim()) %>'
                                    alt='<%# Eval("imgname").ToString().Trim() %>'
                                    class="me-3" />
                            </a>
                            <div class="flex-grow-1">
                                <h5 class="mb-1"><%# Eval("pname") %></h5>
                                <p class="mb-1 text-muted">Size: <%# Eval("sizenamee") %></p>
                                <p class="mb-1">
                                    <span class="text-decoration-line-through text-muted"><%# Eval("price","{0:00,0}") %></span>
                                    <span class="text-danger fw-bold"><%# Eval("pselprice","{0:c}") %></span>
                                </p>
                            </div>
                            <%--<asp:Button ID="btnRemove1" runat="server" CssClass="btn btn-sm btn-outline-danger" Text="Remove" OnClick="btnRemove1_Click"/>--%>
                             <asp:Button ID="btnRemove1" runat="server" Text="Remove" 
                            CommandArgument='<%# Eval("pid") + "-" + Eval("sizeidd") %>' 
                            OnClick="btnRemove1_Click" CssClass="btn btn-danger" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <!-- Repeat the above cart-item block for other items -->
            </div>

            <!-- Price Details -->
            <div class="col-md-4">
                <div class="price-detail">
                    <h5>Price Details</h5>
                    <div class="d-flex justify-content-between">
                        <span>Cart Total</span>
                        <span id="spancarttotal" runat="server"></span>
                    </div>
                    <div class="d-flex justify-content-between">
                        <span>Cart Discount</span>
                        <span class="text-success" id="spandiscaunt" runat="server"></span>
                    </div>
                    <hr />
                    <div class="d-flex justify-content-between fw-bold">
                        <span>Total</span>
                        <span id="spantotal" runat="server"></span>
                    </div>
                    <asp:Button ID="btnBuyNow" runat="server" CssClass="btn btn-success mt-3 w-100" Text="Buy Now" OnClick="btnBuyNow_Click" CausesValidation="false"/>
                    <!-- add CausesValidation="false" so it works even if you disable it -->



                </div>
            </div>
        </div>
    </div>

</asp:Content>
