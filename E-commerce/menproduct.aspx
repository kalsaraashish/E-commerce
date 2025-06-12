<%@ Page Title="" Language="C#" MasterPageFile="~/usertemplate.Master" AutoEventWireup="true" CodeBehind="menproduct.aspx.cs" Inherits="E_commerce.menproduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <div class="container my-5 animate-on-load">
    <div class="row g-4">
        <asp:Repeater ID="rp1" runat="server">
            <ItemTemplate>

                <div class="col-md-4">
                    <a href="viewproduct.aspx?pid=<%# Eval("pid") %>" style="text-decoration:none; color:black">

                    <div class="card h-100">

                        <img src='<%# ResolveUrl("img/productimg/"+Eval("pid")+"/"+Eval("imgname").ToString().Trim()+Eval("extension").ToString().Trim()) %>'
                            class="card-img-top card-img"
                            alt='<%# Eval("imgname").ToString().Trim() %>' />
                      
                        <!-- Card Body -->
                        <div class="card-body">
                            <!-- Brand Name -->
                            <h6 class="text-muted"><%# Eval("pname") %></h6>
                            <!-- Product Name -->
                            <h5 class="card-title"><%# Eval("pname") %></h5>
                            <!-- Product Description -->
                            <p class="card-text"><%# Eval("pdescription") %></p>
                            <!-- Prices -->
                            <div class="d-flex justify-content-between   align-items-center mb-3">
                                <span class="fw-bold text-danger"><%# Eval("price", "{0:0,00}") %></span>
                                <span class="text-success text-decoration-line-through">(<%# Eval("DiscAmount", "{0:c}") %>off)</span>
                                <span class="text-success text-decoration-through"><%# Eval("PSelPrice", "{0:c}") %></span>
                            </div>
                            <!-- Buy Now Button -->
                            
                        </div>
                    </div>
                          </a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
</asp:Content>
