<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="Withdrawal.aspx.cs" Inherits="ATM_Transections.Withdrawal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Withdrowal Amount</h2>
        <hr />

        <div class="form-group row">
            <label for="lblWithdrowalAmount" class="col-sm-3 col-form-label">Enter Withdrowal Amount</label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtWithdrowal" runat="server" class="form-control" placeholder="Enter Amount" />
                <asp:RequiredFieldValidator ID="rfvWithdrowal" runat="server" ControlToValidate="txtWithdrowal" ErrorMessage="Please Enter Amount" Display="Dynamic" ForeColor="Red" ValidationGroup="Withdrowal" />
                <asp:RegularExpressionValidator ID="revWithdrowal" runat="server" ControlToValidate="txtWithdrowal" ErrorMessage="Please Enter Digit or Valid Digit" Display="Dynamic" ValidationExpression="^[0-9]+$" ForeColor="Red" ValidationGroup="Withdrowal" ></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-10">
                <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Submit" ValidationGroup="Withdrowal" OnClick="btnSave_Click" />

            </div>
        </div>
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>

</asp:Content>
