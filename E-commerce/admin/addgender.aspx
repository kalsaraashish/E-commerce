<%@ Page Title="" Language="C#" MasterPageFile="~/admintemp.Master" AutoEventWireup="true" CodeBehind="addgender.aspx.cs" Inherits="E_commerce.admin.addgender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container py-5 my-5 fade-in">
        <div class="container d-flex justify-content-center align-items-center ">
            <div class=" p-4 rounded-4" style="width: 100%; max-width: 400px;">
                <h2 class="text-center mb-4">Add Gender</h2>
                <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-danger d-none" EnableViewState="false" />
                <div class="mb-3">
                    <asp:TextBox ID="gname" runat="server" CssClass="form-control" placeholder="Gender Name" />
                    <asp:RequiredFieldValidator ID="r1" runat="server" ControlToValidate="gname" CssClass="text-danger" ErrorMessage="Enter Gender Name"></asp:RequiredFieldValidator>
                </div>
                <div class="d-grid">
                    <asp:Button ID="btnLogin" runat="server" Text="Add Gender" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                </div>
            </div>
        </div>
        <!-- Brand List Table -->
        <asp:Repeater ID="gen" runat="server">
            <HeaderTemplate>
                <div class="table-responsive">
                    <h2 class="text-left mb-4">Gender Name :</h2>
                    <hr />
                    <table class="table table-bordered table-striped table-hover">
                        <thead class="table-ligt">
                            <tr>
                                <th>Sr no.</th>
                                <th>Gender Name</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
            </HeaderTemplate>

            <ItemTemplate>

                <tr>
                    <td><%# Eval("genid") %></td>
                    <td><%# Eval("genname") %></td>

                    <td>
                        <a href="edit_gender.aspx?genid=<%# Eval("genid") %>" class="btn btn-primary btn-sm me-1">Edit
                        </a>
                        <a href="delete_gender.aspx?genid=<%# Eval("genid") %>" class="btn btn-danger btn-sm me-1">Delete
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
