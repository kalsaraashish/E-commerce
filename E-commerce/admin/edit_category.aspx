<%@ Page Title="" Language="C#" MasterPageFile="~/admintemp.Master" AutoEventWireup="true" CodeBehind="edit_category.aspx.cs" Inherits="E_commerce.admin.edit_category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container py-5 my-5 fade-in">
        <div class="d-flex justify-content-center align-items-center mb-5">
            <div style="width: 100%; max-width: 400px; margin-top: 1rem;">
                <h2 class="text-center mb-4">Edit Category</h2>

                <div class="mb-5">
                    <asp:TextBox ID="cname" runat="server" CssClass="form-control" placeholder="Edit Category" />
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
                    <asp:Button ID="catbtn" runat="server" Text="Edit Category" CssClass="btn btn-primary" ValidationGroup="catGroup" OnClick="catbtn_Click" />
                </div>

            </div>
        </div>
    </div>

</asp:Content>
