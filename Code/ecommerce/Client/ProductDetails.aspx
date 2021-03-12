<%@ Page Title="" Language="C#" MasterPageFile="~/Client.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="Client_ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <br />
        <br />

        <div class="row">
            <div class="col-md-3">
                <div>
                    <asp:Image ID="imgProduct" runat="server" ImageUrl='<%#Eval("ProductImage") %>' Height="300px" Width="250px" />
                </div>
                <br />
                <div>
                    <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CssClass="btn btn-warning" OnClick="btnAddToCart_Click"></asp:Button>
                </div>
            </div>
            <div class="col-md-8" style="padding-left: 50px">
                <div>
                    <h1>
                        <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("ProductName") %>'></asp:Label>
                    </h1>
                </div>
                <br />
                <div>
                    <pre><asp:Label ID="lblDetail" runat="server" Text='<%#Eval("ProductDetails") %>'></asp:Label></pre>
                </div>
                <div>
                    <h3>
                        <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("ProductPrice") %>'></asp:Label>
                        <i class="fa fa-inr" style="font-size: 20px"></i></h3>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

