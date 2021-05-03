<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="Admin_ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <script src="../Scripts/jquery-3.6.0.min.js"></script>

    <link href="//cdn.datatables.net/1.10.24/css/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="//cdn.datatables.net/1.10.24/js/jquery.dataTables.js"></script>
    <%--<script src="//cdn.datatables.net/1.10.24/js/dataTables.bootstrap.js"></script>--%>

    <%--<script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                method: 'POST',
                url: 'ProductList.aspx/FillProductView',
                contentType: "application/json",
                dataType: 'json',
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        });

        function OnSuccess(response) {
            var items = JSON.parse(response.d);
            $("#datatable").DataTable({
                data: items,
                columns: [
                    //{
                    //    bSortable: false,
                    //    data: 'ProductID.Value',
                    //    mRender: function (data) {
                    //        return '<a href="ProductAddEdit.aspx?ProductID=' + data + '"><i class="fa fa-pencil" style="font-size: 18px;"></i></a> &nbsp; <button id="delete" onclick="Delete('+ data +')"><i class="fa fa-trash-o" style = "font-size: 18px;"></i></button> ';
                    //    }
                    //},
                    { data: 'ProductName.Value' },
                    { data: 'ProductQuantity.Value' },
                    { data: 'ProductDetails.Value' },
                    { data: 'ProductPrice.Value' },
                    {
                        data: 'ProductImage.Value',
                        'render': function (data) {
                            return '<img src='+ data.replace("~","..") +' style="height:100px;width:100px"/>';
                        }
                    }
                ]

             });
        };
        function Delete(ProductID) {
            $.ajax({
                method: 'POST',
                url: 'ProductList.aspx/Delete',
                contentType: "application/json",
                data: '{ ProductID : ' + ProductID + '}',
                dataType: 'json',
                success: $document.getElementById('#lblError').innerHTML = "Record Deleted",
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        }
    </script>--%>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#datatable').DataTable({
                destroy: true,
                paging: true,
                processing: true,
                "bSort": false,
                "autoWidth": false,
                "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
                ordering: [],
                serverSide: true,
                ajax: {
                    url: "ProductList.aspx/SelectAllDataByServerSide",
                    type: 'POST',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: function (data) {
                        return "{'draw':'" + data.start + "','start':'" + data.start + "','length':'" + data.length + "','order':'" + JSON.stringify(data.order) + "', 'search':'" + data.search.value + "'}";
                    },
                    dataSrc: function (data) {
                        var jsonData = JSON.parse(data.d);
                        data.recordsTotal = jsonData.recordsTotal;
                        data.recordsFiltered = jsonData.recordsFiltered;
                        console.log(data);
                        return jsonData.data;
                    }
                },
                "columns": [
                    { "data": "ProductName.Value" },
                    { "data": "ProductQuantity.Value" },
                    { "data": "ProductDetails.Value" },
                    { "data": "ProductPrice.Value" },
                    {
                        "data": "ProductImage.Value",
                        'render': function (data) {
                            return '<img src=' + data.replace("~", "..") + ' style="height:100px;width:100px"/>';
                        }
                    }
                ]
            });
        });
    </script>
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
            <table id="datatable" class="table table-responsive table-hover">
                <thead>
                    <tr>
                        <%--<th>Action</th>--%>
                        <th>ProductName</th>
                        <th>Quantity</th>
                        <th>Product Details</th>
                        <th>Product Price</th>
                        <th>Product Image</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
            <br />
            <br />
            <%--<asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-striped" ForeColor="#333333" GridLines="None" OnRowCommand="gvProduct_RowCommand">
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

            </asp:GridView>--%>
        </div>
    </div>
</asp:Content>

