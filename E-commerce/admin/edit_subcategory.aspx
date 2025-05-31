<%@ Page Title="" Language="C#" MasterPageFile="~/admintemp.Master" AutoEventWireup="true" CodeBehind="edit_subcategory.aspx.cs" Inherits="E_commerce.admin.edit_subcategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container py-5 my-5 fade-in">
        <div class="d-flex justify-content-center align-items-center mb-5">
            <div style="width: 100%; max-width: 400px;">
                <h2 class="text-center mb-4 m-4">Edit SubCategory</h2>
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

                    <asp:Button ID="subcatbtn" runat="server" Text="Edit SubCategory" CssClass="btn btn-primary" ValidationGroup="subcatGroup" OnClick="subcatbtn_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
