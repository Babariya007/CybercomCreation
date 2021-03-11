<%@ Page Title="" Language="C#" MasterPageFile="~/Client.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Client_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div>
            <h2>Welcome e-Commerce</h2>
            <asp:Label ID="lblError" runat="server" EnableViewState="false" Font-Size="Large"></asp:Label>
        </div>
        <hr />
        <br />
        <br />
        <div>
            <asp:Repeater ID="rpProducts" runat="server">
                <ItemTemplate>
                    <div class="col-sm-3" style="margin-bottom: 20px">
                        <div class="card" style="width: 18rem;">
                            <asp:HyperLink ID="hlProduct" runat="server" NavigateUrl='<%# "~/Client/ProductDetails.aspx?ProductID=" + Eval("ProductID").ToString().Trim() %>'>
                                <asp:Image ID="imgProduct" runat="server" ImageUrl='<%#Eval("ProductImage") %>' alt='<%#Eval("ProductName") %>' class="card-img-top" Height="200" Width="271" />
                            </asp:HyperLink>

                            <div class="card-body">
                                <h3 class="card-title"><%#Eval("ProductName") %></h3>
                                <h4 class="card-text" style="color: green;"><%#Eval("ProductPrice") %> <i class="fa fa-inr" style="font-size: 18px"></i></h4>
                                <asp:HyperLink ID="hlGotoProduct" runat="server" NavigateUrl='<%#"~/Client/ProductDetails.aspx?ProductID=" + Eval("ProductID").ToString().Trim() %>' class="btn btn-primary">Go To Product</asp:HyperLink>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

