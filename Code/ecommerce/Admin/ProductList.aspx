<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="Admin_ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    
    <link rel="stylesheet" type="text/css" href="//cdn.datatables.net/1.10.24/css/jquery.dataTables.min.css"/>
    <script type="text/javascript" src="//cdn.datatables.net/1.10.24/js/jquery.dataTables.min.js"></script>
    <script src="https://code.jquery.com/jquery-1.12.0.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#gvProduct').DataTable();
        });
    </script>

    <%--<script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                url: 'ProductService.asmx/SelectAll',
                method: 'post',
                dataType: 'json',
                success: function (data) {
                    $('#datatable').dataTable({
                        data: data,
                        columns: [
                            { 'data': 'ProductName'},
                            { 'data': 'ProductQuantity' },
                            { 'data': 'ProductDetails' },
                            { 'data': 'ProductPrice' },
                            { 'data': 'ProductImage' }
                        ]
                    });
                }
            });
        });
    </script>--%>
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
            <%--<table id="datatable" class="table table-responsive table-hover">
                <tr>
                    <th>ProductName</th>
                    <th>Quantity</th>
                    <th>Product Details</th>
                    <th>Product Price</th>
                    <th>Product Image</th>
                </tr>

            </table>--%>
            <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-striped" ForeColor="#333333" GridLines="None" OnRowCommand="gvProduct_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Sr No">
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlEdit" NavigateUrl='<%# "~/Admin/ProductAddEdit.aspx?ProductID=" + Eval("ProductID").ToString().Trim() %>' ToolTip="Edit Record"><i class="fa fa-edit"></i></asp:HyperLink>

                                <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteRecord" CommandArgument='<%#Eval("ProductID") %>' OnClientClick="return confirm('Are you sure you want to delete this item?');" ToolTip="Delete Record"><i class="fa fa-trash"></i></asp:LinkButton>
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

