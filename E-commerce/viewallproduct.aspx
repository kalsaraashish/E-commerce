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
                        <!-- Product Image -->
                        <%--<img src="img/productimg/<%# Eval("pid") %>/<%# Eval("imgname") %><%# Eval("extension") %>" 
                             class="card-img-top card-img" 
                             alt="<%# Eval("imgname") %>">--%>


                       <%-- <img src='<%# ResolveUrl("~/img/productimg/" + Eval("pid") + "/" + Eval("imgname") + Eval("extension")) %>' 
     class="card-img-top card-img" 
     alt='<%# Eval("imgname") %>' />--%>

                        <%--<img src='<%# ResolveUrl("img/productimg/" + Eval("pid") + "/" + Eval("imgname") + Eval("extension")) %>' 
     class="card-img-top card-img" 
     alt='<%# Eval("imgname") %>' />--%>

                        <img src='<%# ResolveUrl("~/img/productimg/" + Eval("imgname") + Eval("extension")) %>' 
     class="card-img-top card-img" 
     alt='<%# Eval("imgname") %>' />




                        <!-- Card Body -->
                        <div class="card-body">
                            <!-- Brand Name -->
                            <h6 class="text-muted"><%# Eval("name") %></h6>

                            <!-- Product Name -->
                            <h5 class="card-title"><%# Eval("pname") %></h5>

                            <!-- Product Description -->
                            <p class="card-text"><%# Eval("pdescription") %></p>

                            <!-- Prices -->
                            <div class="d-flex justify-content-between align-items-center mb-3">
                                <span class="fw-bold text-danger"><%# Eval("price", "{0:0,00}") %></span>
                                <span class="text-success text-decoration-line-through">(<%# Eval("DiscAmount", "{0:c}") %>off)</span>
                                <span class="text-success text-decoration-through"><%# Eval("PSelPrice", "{0:c}") %></span>
                            </div>

                            <!-- Buy Now Button -->
                            <a href="#" class="btn btn-primary w-100">Buy Now</a>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>




</asp:Content>
