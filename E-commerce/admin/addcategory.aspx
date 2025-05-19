<%@ Page Title="" Language="C#" MasterPageFile="~/admintemp.Master" AutoEventWireup="true" CodeBehind="addcategory.aspx.cs" Inherits="E_commerce.admin.addcategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container d-flex justify-content-center align-items-center fade-in" style="height: 40vh;">
        <div class="card shadow p-4 rounded-4" style="width: 100%; max-width: 400px;">
            <h2 class="text-center mb-4">Add Category</h2>
          
            <div class="mb-3">
                <asp:TextBox ID="cname" runat="server" CssClass="form-control" placeholder="Category Name" />
                <asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="cname" CssClass="text-danger" ErrorMessage="Enter Category Name"></asp:RequiredFieldValidator>
            </div>
            <div class="d-grid">
                <asp:Button ID="btnLogin" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnLogin_Click"  />
            </div>
        </div>
    </div>


    <div class="container d-flex justify-content-center align-items-center fade-in" style="height: 50vh;">
    <div class="card shadow p-4 rounded-4" style="width: 100%; max-width: 400px;">
        <h2 class="text-center mb-4">Add SubCategory</h2>
      
        <div class="mb-3">
            <asp:TextBox ID="subcatname" runat="server" CssClass="form-control" placeholder="SubCategory Name" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cname" CssClass="text-danger" ErrorMessage="Enter SubCategory Name"></asp:RequiredFieldValidator>
        </div>
        <div class="d-grid">
            <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-primary"  />
        </div>
    </div>
</div>

</asp:Content>
