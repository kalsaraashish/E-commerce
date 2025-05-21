<%@ Page Title="" Language="C#" MasterPageFile="~/admintemp.Master" AutoEventWireup="true" CodeBehind="addsize.aspx.cs" Inherits="E_commerce.admin.addsize" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



     <div class="container fade-in">
    <div class="container d-flex justify-content-center align-items-left fade-in">

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
                <asp:RequiredFieldValidator ID="r1" runat="server" CssClass="text-danger" ErrorMessage="Select Brand name" ControlToValidate="brlist" ValidationGroup="subcatGroup" ></asp:RequiredFieldValidator>
            </div>

            <div class="mb-3">
                <label for="ddlcategory" class="control-label mb-3">Category</label>

                <asp:DropDownList ID="catlist" runat="server" CssClass="form-select" OnSelectedIndexChanged="catlist_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                <asp:RequiredFieldValidator ID="r2" runat="server" CssClass="text-danger" ErrorMessage="Select Category name" ControlToValidate="catlist" ValidationGroup="subcatGroup" ></asp:RequiredFieldValidator>
            </div>

            <div class="mb-3">
                <label for="ddlsubcategory" class="control-label mb-3">SubCategory</label>

                <asp:DropDownList ID="subcatlist" runat="server" CssClass="form-select"></asp:DropDownList>

                <asp:RequiredFieldValidator ID="r3" runat="server" CssClass="text-danger" ErrorMessage="Select SubCategory name" ControlToValidate="subcatlist" ValidationGroup="subcatGroup" ></asp:RequiredFieldValidator>
            </div>

            <div class="mb-3">
                <label for="ddlgen" class="control-label mb-3">Gender</label>

                <asp:DropDownList ID="genlist" runat="server" CssClass="form-select"></asp:DropDownList>

                <asp:RequiredFieldValidator ID="r4" runat="server" CssClass="text-danger" ErrorMessage="Select Gender name" ControlToValidate="genlist" ValidationGroup="subcatGroup" ></asp:RequiredFieldValidator>
            </div>
            <div class="d-grid">

                <asp:Button ID="btnsize" runat="server" Text="Add Size" CssClass="btn btn-primary" ValidationGroup="subcatGroup" OnClick="btnsize_Click" />
            </div>

        </div>
           </div>
                <!-- Size Table -->
        <asp:Repeater ID="sizerp" runat="server">
            <HeaderTemplate>
                <div class="table-responsive">
                    <h2 class="text-left mb-4">All Sizes Name :</h2>
                    <hr />
                    <table class="table table-bordered table-striped table-hover">
                        <thead class="table-ligt">
                            <tr>
                                <th>Sr no.</th>
                                <th>Size Name</th>
                                <th>Brand Name</th>
                                <th>Category Name</th>
                                <th>Subcategory Name</th>
                                <th>Gender Name</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
            </HeaderTemplate>

            <ItemTemplate>

                <tr>
                    <td><%# Eval("sid") %></td>
                    <td><%# Eval("sizename") %></td>
                    <td><%# Eval("name") %></td>
                    <td><%# Eval("catname") %></td>
                    <td><%# Eval("subcatname") %></td>
                    <td><%# Eval("genname") %></td>
                    <td>
                        <button class="btn btn-sm btn-primary me-1">Edit</button>
                        <button class="btn btn-sm btn-danger">Delete</button>
                    </td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </tbody>
    </table>
</div>
            </FooterTemplate>


        </asp:Repeater>
   

         </div>
        
</asp:Content>
