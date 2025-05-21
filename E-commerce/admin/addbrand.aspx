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
        <div class="table-responsive">
            <table class="table table-bordered table-striped table-hover">
                <thead class="table-dark">
                    <tr>
                        <th>#</th>
                        <th>Brand Name</th>
                        <th>Date Added</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <!-- Example static row (replace with dynamic data binding) -->
                    <tr>
                        <td>1</td>
                        <td>Nike</td>
                        <td>2025-05-01</td>
                        <td>
                            <button class="btn btn-sm btn-warning me-1">Edit</button>
                            <button class="btn btn-sm btn-danger">Delete</button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

    </div>

</asp:Content>
