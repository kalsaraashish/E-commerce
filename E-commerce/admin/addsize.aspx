<%@ Page Title="" Language="C#" MasterPageFile="~/admintemp.Master" AutoEventWireup="true" CodeBehind="addsize.aspx.cs" Inherits="E_commerce.admin.addsize" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


   <%-- <div class="container d-flex justify-content-center align-items-center fade-in" style="height: 77vh;">--%>
    <div class="container py-5 my-5 d-flex justify-content-center align-items-center fade-in">

        <div class=" p-4 rounded-4" style="width: 100%; max-width: 400px;">

            <h2 class="text-center mb-4 m-4">Add Size</h2>
            <div class="mb-3">
                <asp:TextBox ID="sizename" runat="server" CssClass="form-control" placeholder="Size Name" />
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2"
                    runat="server"
                    ControlToValidate="sizename"
                    CssClass="text-danger"
                    ErrorMessage="Enter SubCategory Name"
                    ValidationGroup="subcatGroup">
                </asp:RequiredFieldValidator>
            </div>
            <div class="mb-3">
                <label for="ddlbrand" class="control-label mb-3">Brand</label>
                <asp:DropDownList ID="brlist" runat="server" CssClass="form-select"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="r1" runat="server" CssClass="text-denger" ErrorMessage="Select Brand name" ControlToValidate="brlist"></asp:RequiredFieldValidator>
            </div>

            <div class="mb-3">
                <label for="ddlcategory" class="control-label mb-3">Category</label>

                <asp:DropDownList ID="catlist" runat="server" CssClass="form-select"></asp:DropDownList>

                <asp:RequiredFieldValidator ID="r2" runat="server" CssClass="text-denger" ErrorMessage="Select Category name" ControlToValidate="catlist"></asp:RequiredFieldValidator>
            </div>

            <div class="mb-3">
                <label for="ddlsubcategory" class="control-label mb-3">SubCategory</label>

                <asp:DropDownList ID="subcatlist" runat="server" CssClass="form-select"></asp:DropDownList>

                <asp:RequiredFieldValidator ID="r3" runat="server" CssClass="text-denger" ErrorMessage="Select SubCategory name" ControlToValidate="subcatlist"></asp:RequiredFieldValidator>
            </div>

            <div class="mb-3">
                <label for="ddlgen" class="control-label mb-3">Gender</label>

                <asp:DropDownList ID="genlist" runat="server" CssClass="form-select"></asp:DropDownList>

                <asp:RequiredFieldValidator ID="r4" runat="server" CssClass="text-denger" ErrorMessage="Select Gender name" ControlToValidate="genlist"></asp:RequiredFieldValidator>
            </div>
            <div class="d-grid">

                <asp:Button ID="subcatbtn" runat="server" Text="Add Size" CssClass="btn btn-primary" ValidationGroup="subcatGroup" />
            </div>

        </div>

    </div>



</asp:Content>
