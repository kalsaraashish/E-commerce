﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admintemp.Master" AutoEventWireup="true" CodeBehind="addproduct.aspx.cs" Inherits="E_commerce.admin.addproduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

    .qty-box { max-width: 90px }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container mt-5 fade-in" id="form1" runat="server">
        
        <h2 class="mb-4">Product Details</h2>
        <div class="mb-3">
            <label for="txtDescription" class="form-label">Product Name</label>
            <asp:TextBox ID="pname" runat="server" CssClass="form-control"></asp:TextBox>
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
                <asp:DropDownList ID="category" runat="server" CssClass="form-select" OnSelectedIndexChanged="category_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </div>
            <div class="col-md-4">
                <label for="ddlSubCategory" class="form-label">Subcategory</label>
                <asp:DropDownList ID="subcategory" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="subcategory_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>

        <div class="row mb-3">

            <div class="col-md-4">
                <label for="gender" class="form-label">Gender</label>
                <asp:DropDownList ID="gen" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="gen_SelectedIndexChanged">
                </asp:DropDownList>
            </div>

           <%-- <div class="col-md-4">
                <label for="dize" class="form-label">Size</label>
                <asp:CheckBoxList ID="sizeList" runat="server" CssClass="form-check">
                </asp:CheckBoxList>
            </div>
                    <div class="col-md-4">
            <label for="pquantity" class="form-label">Product Quantity</label>
            <asp:TextBox ID="pquantity" runat="server" CssClass="form-control"></asp:TextBox>
        </div>--%>
            <div class="row mb-3">
            <div class="col-md-4">
                <label class="form-label fw-bold">Sizes &amp; Stock</label>
                <!-- GridView = size + quantity -->
                <asp:GridView ID="gvSizes" runat="server" AutoGenerateColumns="False"
                              CssClass="table table-sm align-middle">
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSel" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle Width="70px" />
                        </asp:TemplateField>

                        <asp:BoundField DataField="sizename" HeaderText="Size" />

                        <asp:TemplateField HeaderText="Qty">
                            <ItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" CssClass="form-control qty-box"
                                             Text="0" />
                            </ItemTemplate>
                            <HeaderStyle Width="90px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <small class="text-muted"></small>
            </div>
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

        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
    </div>


</asp:Content>
