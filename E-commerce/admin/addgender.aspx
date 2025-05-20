<%@ Page Title="" Language="C#" MasterPageFile="~/admintemp.Master" AutoEventWireup="true" CodeBehind="addgender.aspx.cs" Inherits="E_commerce.admin.addgender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container d-flex justify-content-center align-items-center fade-in" style="height: 77vh;">
    <div class="card shadow p-4 rounded-4" style="width: 100%; max-width: 400px;">
        <h2 class="text-center mb-4">Add Gender</h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-danger d-none" EnableViewState="false" />
        <div class="mb-3">
            <asp:TextBox ID="gname" runat="server" CssClass="form-control" placeholder="Gender Name" />
            <asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="gname" CssClass="text-danger" ErrorMessage="Enter Gender Name"></asp:RequiredFieldValidator>
        </div>
        <div class="d-grid">
            <asp:Button ID="btnLogin" runat="server" Text="Add Gender" CssClass="btn btn-primary" OnClick="btnLogin_Click"  />
        </div>
    </div>
</div>


</asp:Content>
