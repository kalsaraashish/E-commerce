<%@ Page Title="" Language="C#" MasterPageFile="~/usertemplate.Master" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="E_commerce.payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container my-5">
        <div class="row">


            <!-- LEFT: Delivery & Payment -->
            <div class="col-md-7">
                <div class="card shadow rounded-3">
                    <div class="card-header bg-primary text-white">
                        <h5 class="mb-0">Delivery Details</h5>
                    </div>
                    <div class="card-body">
                        <%--<asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger mb-3" HeaderText="Please correct the following errors:" />--%>
                        <asp:HiddenField ID="hdcartamount" runat="server" />
                        <asp:HiddenField ID="hdcartdiscount" runat="server" />
                        <asp:HiddenField ID="hdtotalpayed" runat="server" />
                        <asp:HiddenField ID="hdpidsizeid" runat="server" />

                        <div class="mb-3">
                            <label class="form-label">Full Name</label>
                            <asp:TextBox ID="username" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="username" ErrorMessage="Name is required" CssClass="text-danger" Display="Dynamic" />
                        </div>
                         <div class="mb-3">
                                <label class="form-label">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required" CssClass="text-danger" Display="Dynamic" />
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                                    ErrorMessage="Invalid Email format"
                                    ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
                                    CssClass="text-danger" Display="Dynamic" />
                            </div>

                        <div class="mb-3">
                            <label class="form-label">Address</label>
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                            <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address is required" CssClass="text-danger" Display="Dynamic" />
                        </div>

                        <div class="mb-3">
                            <label class="form-label">Pincode</label>
                            <asp:TextBox ID="txtPincode" runat="server" CssClass="form-control" MaxLength="6" />
                            <asp:RequiredFieldValidator ID="rfvPincode" runat="server" ControlToValidate="txtPincode" ErrorMessage="Pincode is required" CssClass="text-danger" Display="Dynamic" />
                            <asp:RegularExpressionValidator ID="revPincode" runat="server" ControlToValidate="txtPincode" ErrorMessage="Invalid Pincode" ValidationExpression="^\d{6}$" CssClass="text-danger" Display="Dynamic" />
                        </div>

                        <div class="mb-3">
                            <label class="form-label">Mobile Number</label>
                            <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" MaxLength="10" />
                            <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtMobile" ErrorMessage="Mobile number is required" CssClass="text-danger" Display="Dynamic" />
                            <asp:RegularExpressionValidator ID="revMobile" runat="server" ControlToValidate="txtMobile" ErrorMessage="Invalid Mobile Number" ValidationExpression="^\d{10}$" CssClass="text-danger" Display="Dynamic" />
                        </div>

                        <div class="mt-4">
                            <h6>Choose Payment Mode</h6>
                            <div class="form-check">
                                <asp:RadioButton ID="rdoWallet" runat="server" GroupName="payment" CssClass="form-check-input" />
                                <label class="form-check-label">Wallet</label>
                            </div>
                            <div class="form-check">
                                <asp:RadioButton ID="rdoCard" runat="server" GroupName="payment" CssClass="form-check-input" />
                                <label class="form-check-label">Credit/Debit Card</label>
                            </div>
                            <div class="form-check">
                                <asp:RadioButton ID="rdoCOD" runat="server" GroupName="payment" CssClass="form-check-input" Checked="true" />
                                <label class="form-check-label">Cash on Delivery (COD)</label>
                            </div>
                        </div>
                    </div>
            </div>
        </div>
        <!-- RIGHT: Cart Price Details -->
        <div class="col-md-5 mb-4">
            <div class="card shadow rounded-3">
                <div class="card-header bg-primary text-white">
                    <h5 class="mb-0">Price Details</h5>
                </div>
                <div class="card-body">
                    <div class="d-flex justify-content-between mb-3">
                        <span>Cart Total</span>
                        
                        <asp:Label ID="lblCartTotal" runat="server" Text="₹0"></asp:Label>
                    </div>
                    <div class="d-flex justify-content-between mb-3">
                        <span>Discount</span>
                        <asp:Label ID="lblDiscount" runat="server" Text="₹0"></asp:Label>
                    </div>
                    <hr />
                    <div class="d-flex justify-content-between fw-bold">
                        <span>Total</span>
                        <asp:Label ID="lblTotalAmount" runat="server" Text="₹0"></asp:Label>
                    </div>
                    <div class="text-center mt-4">
                        <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" CssClass="btn btn-success w-100" OnClick="btnPlaceOrder_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>

</asp:Content>
