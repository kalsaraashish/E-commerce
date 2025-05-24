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
                <!-- Left side: Product Image -->
                <div class="col-md-6">
                    <asp:Image ID="imgProduct" runat="server" CssClass="product-image" AlternateText="Product Image" />
                </div>

                <!-- Right side: Product Details -->
                <div class="col-md-6">
                    <h5>
                        <asp:Label ID="lblBrand" runat="server" Text="Brand Name"></asp:Label>
                    </h5>
                    <h3>
                        <asp:Label ID="lblProductName" runat="server" Text="Product Name"></asp:Label>
                    </h3>

                    <p>
                        <strong>Price: </strong>
                        <asp:Label ID="lblPrice" runat="server" CssClass="text-decoration-line-through text-muted"></asp:Label>
                        <span class="text-danger">
                            <asp:Label ID="lblDiscount" runat="server"></asp:Label>
                            OFF
                        </span>
                    </p>
                    <p>
                        <strong>Final Price: </strong>
                        <asp:Label ID="lblFinalPrice" runat="server" CssClass="text-success fw-bold"></asp:Label>
                        Riyal
                    </p>

                    <p>
                        <strong>Size:</strong><br />
                        <asp:RadioButtonList ID="rblSize" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="S" Value="S"></asp:ListItem>
                            <asp:ListItem Text="M" Value="M"></asp:ListItem>
                            <asp:ListItem Text="L" Value="L"></asp:ListItem>
                        </asp:RadioButtonList>
                    </p>

                    <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CssClass="btn btn-primary mb-3"  />

                    <hr />

                    <h5>Description</h5>
                    <p>
                        <asp:Label ID="lblDescription" runat="server" Text="This is a detailed product description."></asp:Label>
                    </p>

                    <h5>Material & Care</h5>
                    <p>
                        <asp:Label ID="lblMaterialCare" runat="server" Text="Material and care details go here."></asp:Label>
                    </p>
                </div>
            </div>
    </div>

</asp:Content>
