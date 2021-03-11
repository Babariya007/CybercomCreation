<%@ Page Title="" Language="C#" MasterPageFile="~/Client.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Client_Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div>
            <h2>My Cart</h2>
            <asp:Label ID="lblError" runat="server" Font-Size="Large"></asp:Label>
        </div>
        <hr />
        <br />
        <div class="row">
            <asp:Repeater ID="rpCheckout" runat="server">

                <ItemTemplate>
                    <div class="col-md-2">
                        <div>
                            <asp:Image ID="imgProduct" runat="server" ImageUrl='<%#Eval("ProductImage") %>' Height="150px" Width="150px" />
                        </div>
                        <br />
                        <div class="row col-md-12">
                            <asp:TextBox ID="txtQuantity" runat="server" class="form-control" Text="1" placeholder="Enter Quantity" AutoPostBack="true" OnTextChanged="txtQuantity_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Enter Quentity" Display="Dynamic" ForeColor="Red" ValidationGroup="Product" />
                            <br />
                        </div>
                    </div>
                    <div class="col-md-4" style="padding-left: 50px">
                        <div>
                            <h1>
                                <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("ProductName") %>'></asp:Label>
                            </h1>
                        </div>
                        <div>
                            <h3>
                                <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("ProductPrice") %>'></asp:Label>
                                <i class="fa fa-inr" style="font-size: 20px"></i></h3>
                        </div>
                    </div>
                    <div class="row col-md-4">
                        <div>
                            Quantity :
                    <asp:Label ID="lblQuantity" runat="server"></asp:Label>
                        </div>
                        <br />
                        <div>
                            Price :
                    <asp:Label ID="lblProductPrice" runat="server" Text='<%#Eval("ProductPrice") %>' class="fa fa-inr"></asp:Label>
                        </div>
                        <br />
                        <div>
                            GST Charge 18% :
                    <asp:Label ID="lblGSTCharge" runat="server"></asp:Label>
                        </div>
                        <br />
                        <div>
                            Total Bill :
                    <asp:Label ID="lblTotalBill" runat="server"></asp:Label>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>

            <div>
                <asp:Button ID="btnCheckOut" runat="server" Text="Check Out" CssClass="btn btn-info" />
            </div>
        </div>
    </div>

</asp:Content>

