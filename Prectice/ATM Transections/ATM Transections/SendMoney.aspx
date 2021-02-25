<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="SendMoney.aspx.cs" Inherits="ATM_Transections.SendMoney" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
        <h2>Send Money</h2>
        <hr />

        <div class="form-group row">
            <div class="col-sm-4">
                <asp:Label ID="lblSenderName" runat="server" />
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-4">
                <asp:TextBox ID="txtReciver" runat="server" class="form-control" placeholder="Enter Name Or Number" />
                <asp:RequiredFieldValidator ID="rfvReciver" runat="server" ControlToValidate="txtReciver" ErrorMessage="Please Select Reciver" InitialValue="-1" Display="Dynamic" ForeColor="Red" ValidationGroup="SendMoney" />
                
            </div>
        </div>

        <div class="form-group row">
            <div class="col-sm-10">
                <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Submit" ValidationGroup="SendMoney" />

            </div>
        </div>
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>

</asp:Content>
