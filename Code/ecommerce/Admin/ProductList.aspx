<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="Admin_ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div>
            <h2>Product List</h2>
            <asp:Label ID="lblError" runat="server" Font-Size="Large"></asp:Label>
        </div>
        <hr />
        <br />

        <div style="text-align: right;">
            <asp:HyperLink ID="hlAddNewProduct" runat="server" class="btn btn-primary" NavigateUrl="~/Admin/ProductAddEdit.aspx" Text="Add New Product"></asp:HyperLink>
        </div>
        <br />
        <br />
        <div>
            <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-striped" ForeColor="#333333" GridLines="None" OnRowCommand="gvProduct_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Sr No">
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlEdit" CssClass="btn btn-primary" NavigateUrl='<%# "~/Admin/ProductAddEdit.aspx?ProductID=" + Eval("ProductID").ToString().Trim() %>'><i class="la la-edit"></i>Edit</asp:HyperLink>

                                <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%#Eval("ProductID") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="ProductQuantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="ProductDetails" HeaderText="Product Details" />
                    <asp:BoundField DataField="ProductPrice" HeaderText="Product Price" />
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <div style="text-align: center">
                                <asp:Image ID="imgProduct" runat="server" Height="100px" Width="100px" ImageUrl='<%#Eval("ProductImage") %>'></asp:Image>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />

            </asp:GridView>
        </div>
    </div>
</asp:Content>

