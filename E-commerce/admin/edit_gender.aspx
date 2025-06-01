<%@ Page Title="" Language="C#" MasterPageFile="~/admintemp.Master" AutoEventWireup="true" CodeBehind="edit_gender.aspx.cs" Inherits="E_commerce.admin.edit_gender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container py-5 my-5 fade-in">
    <div class="container d-flex justify-content-center align-items-center ">


        <div class=" p-4 rounded-4" style="width: 100%; max-width: 400px;">
            <h2 class="text-center mb-4">Edit Gender</h2>
            <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-danger d-none" EnableViewState="false" />
            <div class="mb-3">
                <asp:TextBox ID="gname" runat="server" CssClass="form-control" placeholder="Gender Name" />
                <asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="gname" CssClass="text-danger" ErrorMessage="Enter Gender Name"></asp:RequiredFieldValidator>
            </div>
            <div class="d-grid">
                <asp:Button ID="btnLogin" runat="server" Text="Edit Gender" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
            </div>
        </div>
    </div>
        </div>
</asp:Content>
