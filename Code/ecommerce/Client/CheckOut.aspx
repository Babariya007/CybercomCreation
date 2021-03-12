<%@ Page Title="" Language="C#" MasterPageFile="~/Client.master" AutoEventWireup="true" CodeFile="CheckOut.aspx.cs" Inherits="Client_CheckOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <h2>
            <asp:Label ID="lblPageHeader" runat="server">Check Out</asp:Label></h2>
        <hr />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server" EnableViewState="false"></asp:Label>
        <br />

        <div class="form-group row">
            <label for="lblFirstName" class="col-sm-2 col-form-label">First Name</label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtFirstName" runat="server" class="form-control" placeholder="Enter First Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Enter First Name" Display="Dynamic" ForeColor="Red" ValidationGroup="CheckOut" />

            </div>

            <label for="lblLastName" class="col-sm-2 col-form-label">Last Name</label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtLastName" runat="server" class="form-control" placeholder="Enter Last Name"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Enter Last Name" Display="Dynamic" ForeColor="Red" ValidationGroup="CheckOut" />
            </div>
        </div>
        <div class="form-group row">
            <label for="lblAddress" class="col-sm-2 col-form-label">Address</label>
            <div class="col-sm-10">
                <asp:TextBox ID="txtAddress" runat="server" class="form-control" placeholder="Enter Address"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="Enter Address" Display="Dynamic" ForeColor="Red" ValidationGroup="CheckOut" />
            </div>
        </div>
        <div class="form-group row" style="text-align: right">
            <asp:Button ID="btnSave" runat="server" class="btn btn-success" Text="Confirm" ValidationGroup="CheckOut" OnClick="btnSave_Click" />
            <asp:HyperLink ID="hlCancle" runat="server" class="btn btn-danger" Text="Cancle" NavigateUrl="~/Client/Home.aspx" />
        </div>
        <br />
    </div>
</asp:Content>

