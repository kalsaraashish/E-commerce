<%@ Page Title="" Language="C#" MasterPageFile="~/admintemp.Master" AutoEventWireup="true" CodeBehind="adminhomepage.aspx.cs" Inherits="E_commerce.admin.adminhomepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="container py-5 my-5 fade-in">


           <asp:Repeater ID="userdata" runat="server">
            <HeaderTemplate>
                <div class="table-responsive">
                    <h2 class="text-left mb-4">User Data :</h2>
                    <hr />
                    <table class="table table-bordered table-striped table-hover">
                        <thead class="table-ligt">
                            <tr>
                                <th>Sr no.</th>
                                <th>User Name</th>
                                <th>Email</th>
                                <th>Phone number</th>
                                <th>Address</th>
                                <th>Gender</th>
                                <th>Img</th>
                            </tr>
                        </thead>
                        <tbody>
            </HeaderTemplate>

            <ItemTemplate>

                <tr>
                    <td><%# Eval("id") %></td>
                    <td><%# Eval("username") %></td>
                    <td><%# Eval("email") %></td>
                    <td><%# Eval("p_number") %></td>
                    <td><%# Eval("address") %></td>
                    <td><%# Eval("gender") %></td>
                    <td><img src="<%# Eval("img")%>" alt="<%# Eval("img").ToString().Trim() %>" style="height:5rem; border-radius:100%;" /></td>
                    

                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </tbody>
    </table>
</div>
            </FooterTemplate>


        </asp:Repeater>

    </div>

          <div class="container py-5 my-5 fade-in">


           <asp:Repeater ID="pdata" runat="server">
            <HeaderTemplate>
                <div class="table-responsive">
                    <h2 class="text-left mb-4">Purchase Data :</h2>
                    <hr />
                    <table class="table table-bordered table-striped table-hover">
                        <thead class="table-ligt">
                            <tr>
                                <th>Sr no.</th>
                                <th>User Name</th>
                               
                                <th>Total Payed</th>
                                <th>Payment Type</th>
                                <th>Status</th>
                                <th>Address</th>
                               
                            </tr>
                        </thead>
                        <tbody>
            </HeaderTemplate>

            <ItemTemplate>

                <tr>
                    <td><%# Eval("id") %></td>
                    <td><%# Eval("name") %></td>
                    <td><%# Eval("totalpayed", "{0:c}") %></td>
                    <td><%# Eval("paymenttype") %></td>
                    <td><%# Eval("paymentstatus") %></td>
                    <td><%# Eval("address") %> - <%# Eval("pincod") %></td>
                   
                    

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
