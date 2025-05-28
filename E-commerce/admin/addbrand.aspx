<%@ Page Title="" Language="C#" MasterPageFile="~/admintemp.Master" AutoEventWireup="true" CodeBehind="addbrand.aspx.cs" Inherits="E_commerce.admin.addbrand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container py-5 my-5 fade-in">

        <!-- Brand Form -->
        <div class="d-flex justify-content-center align-items-center mb-5">
            <div style="width: 100%; max-width: 400px;">
                <h2 class="text-center mb-4">Add Brand</h2>
                <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-danger d-none" EnableViewState="false" />
                <div class="mb-3">
                    <asp:TextBox ID="brname" runat="server" CssClass="form-control" placeholder="Brand Name" />
                    <asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="brname" CssClass="text-danger" ErrorMessage="Enter Brand Name"></asp:RequiredFieldValidator>
                </div>
                <div class="d-grid">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                </div>
            </div>
        </div>

        <!-- Brand List Table -->
        <asp:Repeater ID="rp" runat="server">
            <HeaderTemplate>
                <div class="table-responsive">
                    <h2 class="text-left mb-4">Brand Name :</h2>
                    <hr />
                    <table class="table table-bordered table-striped table-hover">
                        <thead class="table-ligt">
                            <tr>
                                <th>Sr no.</th>
                                <th>Brand Name</th>
                                <th>Added Date</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
            </HeaderTemplate>

            <ItemTemplate>

                <tr>
                    <td><%# Eval("brid") %></td>
                    <td><%# Eval("name") %></td>
                    <td><%# Eval("date") %></td>
                    <td>
                        <a href="editbrand.aspx?brid=<%# Eval("brid") %>" class="btn btn-primary btn-sm me-1">Edit
                        </a>
                        <a href="editbrand.aspx?brid=<%# Eval("brid") %>" class="btn btn-danger btn-sm me-1">Delete
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

</asp:Content>
