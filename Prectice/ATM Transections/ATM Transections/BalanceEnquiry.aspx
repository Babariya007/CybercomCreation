<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="BalanceEnquiry.aspx.cs" Inherits="ATM_Transections.BalanceEnquiry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2><asp:Label ID="lblUserName" runat="server" ></asp:Label></h2>
        <hr />
        <div>
        <h4>Balance Enquiry</h4>
            <br />
            <br />
            <asp:Label ID="lblBalance" runat="server"></asp:Label>
        </div>
    </div>

</asp:Content>
