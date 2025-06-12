<%@ Page Title="" Language="C#" MasterPageFile="~/admintemp.Master" AutoEventWireup="true" CodeBehind="Viewproduct.aspx.cs" Inherits="E_commerce.admin.Viewproduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="container py-5 my-5 fade-in">
        <asp:Repeater ID="viewproduct" runat="server">
            <HeaderTemplate>
                <div class="table-responsive">
                    <h2 class="text-left mb-4">Product Detail:</h2>
                    <hr />
                    <table class="table table-bordered table-striped table-hover">
                        <thead class="table-ligt">
                            <tr>
                                <th>Sr no.</th>
                                <th>Product Name</th>
                                <th>Price</th>
                                <th>Selling Price</th>
                                <th>Brand</th>
                                <th>Category</th>
                                <th>SubCategory</th>
                                <th>Gender</th>
                                <th>Quntity</th>
                                <th>Description</th>
                                <th>Product Details</th>
                                <th>Material and Care</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
            </HeaderTemplate>

            <ItemTemplate>

                <tr>
                    <td><%# Eval("pid") %></td>
                    <td><%# Eval("pname") %></td>
                    <td><%# Eval("price","{0:0}") %></td>
                    <td><%# Eval("pselprice","{0:0}") %></td>
                    <td><%# Eval("name") %></td>
                   <td><%# Eval("catname") %></td> 
                    <td><%# Eval("subcatname") %></td>
                    <td><%# Eval("genname") %></td>
                    <td><%# Eval("quantity") %></td>
                    <td><%# Eval("pdescription") %></td>
                    <td><%# Eval("productdetails") %></td>
                    <td><%# Eval("matcare") %></td>
                    <td>
                        <a href="<%--edit_gender.aspx?genid=<%# Eval("genid") %>--%>" class="btn btn-primary btn-sm me-1">Edit
                        </a>
                        <a href="delete_product.aspx?pid=<%# Eval("pid") %>" class="btn btn-danger btn-sm me-1">Delete
                        </a>
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
    <div class="container py-5 my-5 fade-in">
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
</asp:Content>
