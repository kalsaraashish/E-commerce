<%@ Page Title="" Language="C#" MasterPageFile="~/admintemp.Master" AutoEventWireup="true" CodeBehind="addbrand.aspx.cs" Inherits="E_commerce.admin.addbrand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container py-5 my-5 d-flex justify-content-center align-items-center fade-in">
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
        <div>
            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">First</th>
                        <th scope="col">Last</th>
                         <th scope="col">Handle</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th scope="row">1</th>
                        <td>Mark</td>
                        <td>Otto</td>
                        <td>@mdo</td>
                    </tr>
                    <tr>
                        <th scope="row">2</th>
                        <td>Jacob</td>
                        <td>Thornton</td>
                        <td>@fat</td>
                    </tr>
                    <tr>
                        <th scope="row">3</th>
                        <td colspan="2">Larry the Bird</td>
                        <td>@twitter</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>


</asp:Content>
