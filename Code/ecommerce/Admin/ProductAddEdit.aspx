<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="ProductAddEdit.aspx.cs" Inherits="Admin_ProductAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <h2>
            <asp:Label ID="lblPageHeader" runat="server"></asp:Label></h2>
        <hr />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server" EnableViewState="false"></asp:Label>
        <br />

        <div class="form-group row">
            <label for="lblProductName" class="col-sm-2 col-form-label">Product Name</label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtProductName" runat="server" class="form-control" placeholder="Enter Product Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvProductName" runat="server" ControlToValidate="txtProductName" ErrorMessage="Enter Product Name" Display="Dynamic" ForeColor="Red" ValidationGroup="Product" />

            </div>

            <label for="lblQuantity" class="col-sm-2 col-form-label">Quantity</label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtQuntity" runat="server" class="form-control" placeholder="Enter Quntity"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtQuntity" ErrorMessage="Enter Quntity" Display="Dynamic" ForeColor="Red" ValidationGroup="Product" />
                <asp:RegularExpressionValidator ID="revQuantity" runat="server" ControlToValidate="txtQuntity" ValidationExpression="^[0-9]+$" Display="Dynamic" ErrorMessage="Please Enter Valid Quantity" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group row">
            <label for="lblProductDetails" class="col-sm-2 col-form-label">Product Details</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtProductDetails" runat="server" class="form-control" TextMode="MultiLine" placeholder="Enter Product Details" Rows="4"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvProductDetails" runat="server" ControlToValidate="txtProductDetails" ErrorMessage="Enter Product Details" Display="Dynamic" ForeColor="Red" ValidationGroup="Product" />
            </div>
        </div>
        <div class="form-group row">
            <label for="lblProductPrice" class="col-sm-2 col-form-label">Product Price</label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtProductPrice" runat="server" class="form-control" placeholder="Enter Product Price"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvProductPrice" runat="server" ControlToValidate="txtProductPrice" ErrorMessage="Enter Deposite Amount" Display="Dynamic" ForeColor="Red" ValidationGroup="Product" />
                <asp:RangeValidator ID="rvProductPrice" runat="server" MinimumValue="1" MaximumValue="9999999999" ControlToValidate="txtProductPrice" ErrorMessage="Amount Must be More then 1" ForeColor="Red" ValidationGroup="Product"></asp:RangeValidator>
            </div>
            <label for="lblProductPrice" class="col-sm-2 col-form-label">Select Product Image</label>
            <div class="col-sm-4">
                <asp:FileUpload ID="FuUpload" runat="server" class="form-control-file" placeholder="Select Product Image" accept=".jpeg, .jpg, .png"></asp:FileUpload>
                <asp:RequiredFieldValidator ID="rfvFileUpload" runat="server" ControlToValidate="FuUpload" ErrorMessage="Select File" Display="Dynamic" ForeColor="Red" ValidationGroup="Product" />
            </div>
        </div>
    <div class="form-group row" style="text-align:right">
            <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Save" ValidationGroup="Product" OnClick="btnSave_Click" />
            <asp:HyperLink ID="hlCancle" runat="server" class="btn btn-danger" Text="Cancle" NavigateUrl="~/Admin/ProductList.aspx" />
    </div>
    <br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
</asp:Content>

