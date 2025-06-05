<%@ Page Title="" Language="C#" MasterPageFile="~/usertemplate.Master" AutoEventWireup="true" CodeBehind="viewproduct.aspx.cs" Inherits="E_commerce.viewproduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .product-image {
            max-width: 100%;
            height: auto;
        }

        .size-button {
            margin-right: 5px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <div class="row">
            <!-- Left side: Product Images as a Bootstrap Carousel -->
            <div class="col-md-6">
                <div id="productCarousel" class="carousel slide" data-bs-ride="carousel" data-bs-interval="3000">
                    <div class="carousel-inner border  shadow-sm rounded">
                        <asp:Repeater ID="rpimg" runat="server">
                            <ItemTemplate>
                                <%# Container.ItemIndex == 0 ? 
                                    "<div class='carousel-item active'>" : 
                                    "<div class='carousel-item'>" %>
                                <img src='<%# ResolveUrl("img/productimg/" + Eval("pid") + "/" + Eval("imgname").ToString().Trim() + Eval("extension").ToString().Trim()) %>'
                                    alt='<%# Eval("imgname").ToString().Trim() %>'
                                    class="d-block w-100 product-image" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <!-- Carousel controls -->
                    <button class="carousel-control-prev" type="button" data-bs-target="#productCarousel" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#productCarousel" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>
            </div>

            <!-- Right side: Product Details -->
            <asp:Repeater ID="rpdetail" runat="server" OnItemDataBound="rpdetail_ItemDataBound">
                <ItemTemplate>
                    <div class="col-md-6">
                        <h5>
                            <asp:Label ID="lblBrand" runat="server" Text="Brand Name"></asp:Label>
                        </h5>
                        <h3>
                            <asp:Label ID="lblProductName" runat="server"><%# Eval("pname") %></asp:Label>
                        </h3>

                        <p>
                            <strong>Price:<%# Eval("price" ,"{0:c}") %></strong>
                            <asp:Label ID="lblPrice" runat="server" CssClass="text-decoration-line-through text-muted"><%# string.Format("{0}",Convert.ToInt64(Eval("price"))-Convert.ToInt64(Eval("pselprice"))) %></asp:Label>
                            <span class="text-danger">
                                <asp:Label ID="lblDiscount" runat="server"></asp:Label>
                                OFF
                            </span>
                        </p>
                        <p>
                            <strong>Final Price: </strong>
                            <asp:Label ID="lblFinalPrice" runat="server" CssClass="text-success fw-bold"><%# Eval("pselprice", "{0:c}") %></asp:Label>
                            Riyal
                        </p>

                        <p>
                            <strong>Size:</strong><br />
                            <asp:RadioButtonList ID="rblSize" runat="server" RepeatDirection="Horizontal">
                              <%--  <asp:ListItem Text="S" Value="S"></asp:ListItem>
                                <asp:ListItem Text="M" Value="M"></asp:ListItem>
                                <asp:ListItem Text="L" Value="L"></asp:ListItem>--%>
                            </asp:RadioButtonList>
                        </p>
                        <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CssClass="btn btn-primary mb-3" OnClick="btnAddToCart_Click"/>
                        <asp:Label ID="errormessage" CssClass="text-danger" runat="server"></asp:Label>
                        <hr />
                        <h5>Description</h5>
                        <p>
                            <asp:Label ID="lblDescription" runat="server"><%# Eval("pdescription") %></asp:Label>
                        </p>
                        <h5>Product Details</h5>
                        <p>
                            <asp:Label ID="lblprdetil" runat="server"><%# Eval("productdetails") %></asp:Label>
                        </p>

                        <h5>Material & Care</h5>
                        <p>
                            <asp:Label ID="lblMaterialCare" runat="server"><%# Eval("matcare") %></asp:Label>
                        </p>
                        <hr />
                        <p><%# ((int)Eval("freedelivery")==1)? "Free delivery" : "" %></p>
                        <p><%# ((int)Eval("30dayret")==1)? "30 Day Return" : "" %></p>
                        <p><%# ((int)Eval("cod")==1)? "Cash On Delivery" : "" %></p>
                    </div>

                    <asp:HiddenField ID="hbrid" runat="server" Value='<%# Eval("pbrid") %>' />
                    <asp:HiddenField ID="hcatid" runat="server" Value='<%# Eval("pcatid") %>' />
                    <asp:HiddenField ID="hsubcatid" runat="server" Value='<%# Eval("psubcatid") %>' />
                    <asp:HiddenField ID="hgenid" runat="server" Value='<%# Eval("pgenid") %>' />
                  
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
