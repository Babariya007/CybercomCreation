<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="SendMoney.aspx.cs" Inherits="ATM_Transections.SendMoney" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Send Money</h2>
        <hr />

        <div class="form-group row">
            <div class="col-sm-4">
                <h3>
                    <asp:Label ID="lblSenderName" runat="server" /></h3>
                Send to
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-4">
                <asp:TextBox ID="txtReciverName" runat="server" class="form-control" placeholder="Enter Reciver Name" />
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtReciverName" ErrorMessage="Please Enter Reciver Name" Display="Dynamic" ForeColor="Red" ValidationGroup="SendMoney" />
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-4">
                <asp:TextBox ID="txtReciverMobileNo" runat="server" class="form-control" MaxLength="10" placeholder="Enter Reciver Mobile No" />
                <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtReciverMobileNo" ErrorMessage="Please Enter Reciver Mobile No" Display="Dynamic" ForeColor="Red" ValidationGroup="SendMoney" />
                <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ControlToValidate="txtReciverMobileNo" ValidationExpression="[0-9]{10}" Display="Dynamic" ErrorMessage="Please Enter Valid Mobile No" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-4">
                <asp:TextBox ID="txtAmount" runat="server" class="form-control" placeholder="Enter Amount" />
                <asp:RequiredFieldValidator ID="rfvAmount" runat="server" ControlToValidate="txtAmount" ErrorMessage="Please Enter Amount" Display="Dynamic" ForeColor="Red" ValidationGroup="SendMoney" />
                <asp:RegularExpressionValidator ID="revAmount" runat="server" ControlToValidate="txtAmount" ValidationExpression="[0-9]+" Display="Dynamic" ErrorMessage="Please Enter Valid Mobile No" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="form-group row">
            <div class="col-sm-10">
                <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Submit" ValidationGroup="SendMoney" OnClick="btnSave_Click" />
            </div>
        </div>
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>

</asp:Content>
