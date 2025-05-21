<%@ Page Title="" Language="C#" MasterPageFile="~/admintemp.Master" AutoEventWireup="true" CodeBehind="addcategory.aspx.cs" Inherits="E_commerce.admin.addcategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container py-5 my-5 fade-in">

        <div class="d-flex justify-content-center align-items-center mb-5">
            <div style="width: 100%; max-width: 400px;">
                <h2 class="text-center mb-4">Add Category</h2>

                <div class="mb-3">
                    <asp:TextBox ID="cname" runat="server" CssClass="form-control" placeholder="Category Name" />
                    <asp:RequiredFieldValidator
                        ID="r1"
                        runat="server"
                        ControlToValidate="cname"
                        CssClass="text-danger"
                        ErrorMessage="Enter Category Name"
                        ValidationGroup="catGroup">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="d-grid">
                    <asp:Button ID="catbtn" runat="server" Text="Add Category" CssClass="btn btn-primary" OnClick="btnLogin_Click" ValidationGroup="catGroup" />
                </div>


                <h2 class="text-center mb-4 m-4">Add SubCategory</h2>
                <label for="ddlMaincat" class="control-label mb-3">Main category :</label>
                <div class="mb-3">
                    <asp:DropDownList ID="mcatdroplist" runat="server" CssClass="form-select"></asp:DropDownList>

                </div>
                <div class="mb-3">
                    <asp:TextBox ID="subcatname" runat="server" CssClass="form-control" placeholder="SubCategory Name" />
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2"
                        runat="server"
                        ControlToValidate="subcatname"
                        CssClass="text-danger"
                        ErrorMessage="Enter SubCategory Name"
                        ValidationGroup="subcatGroup">
                    </asp:RequiredFieldValidator>
                </div>
                <div class="d-grid">

                    <asp:Button ID="subcatbtn" runat="server" Text="Add SubCategory" CssClass="btn btn-primary" OnClick="subcatbtn_Click" ValidationGroup="subcatGroup" />
                </div>

            </div>
        </div>
        <!--- Category table --->
        <asp:Repeater ID="rp" runat="server">
            <HeaderTemplate>
                <h2 class="text-left mb-4">Category Name :</h2>
                <hr />
                <div class="table-responsive">
                    <table class="table table-bordered table-striped table-hover">
                        <thead class="table-ligt">
                            <tr>
                                <th>Sr no.</th>
                                <th>Category Name</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
            </HeaderTemplate>

            <ItemTemplate>

                <tr>
                    <td><%# Eval("catid") %></td>
                    <td><%# Eval("catname") %></td>

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


         <!--- SubCategory table --->
 <asp:Repeater ID="rp2" runat="server">
     <HeaderTemplate>
         <h2 class="text-left mb-4">SubCategory Name :</h2>
         <hr />
         <div class="table-responsive">
             <table class="table  table-bordered table-striped table-hover" >
                 <thead class="table-ligt ">
                     <tr>
                         <th>Sr no.</th>
                         <th>SubCategory Name</th>
                         <th>Main Category</th>
                         <th>Actions</th>
                     </tr>
                 </thead>
                 <tbody>
     </HeaderTemplate>

     <ItemTemplate>

         <tr>
             <td><%# Eval("subcatid") %></td>
             <td><%# Eval("subcatname") %></td>
             <td><%# Eval("catname") %></td>

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
