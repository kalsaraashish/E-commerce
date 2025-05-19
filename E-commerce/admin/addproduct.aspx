<%@ Page Title="" Language="C#" MasterPageFile="~/admintemp.Master" AutoEventWireup="true" CodeBehind="addproduct.aspx.cs" Inherits="E_commerce.admin.addproduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container mt-5">
        <h2 class="mb-4">Product Details</h2>
        <div class="mb-3">
            <label for="txtDescription" class="form-label">Product Name</label>
            <asp:TextBox ID="pname" runat="server" CssClass="form-control" ></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtDescription" class="form-label">Price</label>
            <asp:TextBox ID="price" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtDescription" class="form-label">Selling Price</label>
            <asp:TextBox ID="sprice" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="row mb-3">
            <div class="col-md-4">
                <label for="ddlBrand" class="form-label">Brand</label>
                <asp:DropDownList ID="brand" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="col-md-4">
                <label for="ddlCategory" class="form-label">Category</label>
                <asp:DropDownList ID="category" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="col-md-4">
                <label for="ddlSubCategory" class="form-label">Subcategory</label>
                <asp:DropDownList ID="subcategory" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
        </div>

        <div class="row mb-3">
            <div class="col-md-4">
                <label for="dize" class="form-label">Size</label>
                <asp:DropDownList ID="size" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Select Size" Value="" />
                    <asp:ListItem Text="Small" Value="S" />
                    <asp:ListItem Text="Medium" Value="M" />
                    <asp:ListItem Text="Large" Value="L" />
                    <asp:ListItem Text="XL" Value="XL" />
                </asp:DropDownList>
            </div>
        </div>

        <div class="mb-3">
            <label for="txtDescription" class="form-label">Description</label>
            <asp:TextBox ID="description" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label for="txtProductDetails" class="form-label">Product Details</label>
            <asp:TextBox ID="productdetails" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label for="txtMaterialCare" class="form-label">Material and Care</label>
            <asp:TextBox ID="materialcare" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label class="form-label">Upload Product Images</label>
            <div class="row">
                <div class="col-md-3 mb-2">
                    <asp:FileUpload ID="fuImage1" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-3 mb-2">
                    <asp:FileUpload ID="fuImage2" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-3 mb-2">
                    <asp:FileUpload ID="fuImage3" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-3 mb-2">
                    <asp:FileUpload ID="fuImage4" runat="server" CssClass="form-control" />
                </div>
            </div>
        </div>

        <div class="mb-3 form-check">
            <asp:CheckBox ID="chkFreeDelivery" runat="server" CssClass="form-check-input" />
            <label class="form-check-label" for="chkFreeDelivery">Free Delivery</label>
        </div>

        <div class="mb-3 form-check">
            <asp:CheckBox ID="chk30DayReturn" runat="server" CssClass="form-check-input" />
            <label class="form-check-label" for="chk30DayReturn">30 Day Return</label>
        </div>

        <div class="mb-3 form-check">
            <asp:CheckBox ID="chkCOD" runat="server" CssClass="form-check-input" />
            <label class="form-check-label" for="chkCOD">Cash On Delivery (COD)</label>
        </div>

        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary"  />
    </div>


</asp:Content>
