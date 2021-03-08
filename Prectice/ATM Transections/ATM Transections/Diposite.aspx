<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="Diposite.aspx.cs" Inherits="ATM_Transections.Diposite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Diposite Amount</h2>
        <hr />
        <div class="form-group row">
            <label for="lblDipositeAmount" class="col-sm-3 col-form-label">Enter Diposite Amount</label>
            <div class="col-sm-4">
                <asp:TextBox ID="txtDiposite" runat="server" class="form-control" placeholder="Enter Amount" />
                <asp:RequiredFieldValidator ID="rfvDiposite" runat="server" ControlToValidate="txtDiposite" ErrorMessage="Please Enter Amount" Display="Dynamic" ForeColor="Red" ValidationGroup="Diposite" />
                <asp:RegularExpressionValidator ID="revDiposite" runat="server" ControlToValidate="txtDiposite" ErrorMessage="Please Enter Digit or Valid Digit" Display="Dynamic" ValidationExpression="^[0-9]+$" ForeColor="Red" ValidationGroup="Withdrowal" ></asp:RegularExpressionValidator>

            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-10">
                <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Submit" ValidationGroup="Diposite" OnClick="btnSave_Click" />

            </div>
        </div>
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>

    </div>
</asp:Content>
