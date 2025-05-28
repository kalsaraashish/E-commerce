<%@ Page Title="" Language="C#" MasterPageFile="~/admintemp.Master" AutoEventWireup="true" CodeBehind="editbrand.aspx.cs" Inherits="E_commerce.admin.editbrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!-- Brand Form -->
 <div class="d-flex justify-content-center align-items-center mb-5">
     <div style="width: 100%; max-width: 400px;">
         <h2 class="text-center mb-4">Edit Brand</h2>
         <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-danger d-none" EnableViewState="false" />
         <div class="mb-3">
             <asp:TextBox ID="brname" runat="server" CssClass="form-control" placeholder="Brand Name" />
             <asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="brname" CssClass="text-danger" ErrorMessage="Enter Brand Name"></asp:RequiredFieldValidator>
         </div>
         <div class="d-grid">
             <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click"  />
         </div>
     </div>
 </div>
</asp:Content>
