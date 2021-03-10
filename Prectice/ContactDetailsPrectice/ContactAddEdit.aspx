<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.Master" AutoEventWireup="true" CodeBehind="ContactAddEdit.aspx.cs" Inherits="ContactDetailsPrectice.ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </h2>
        <hr />
        <div class="form-group row">
            <label for="txtContactName" class="col-md-2 col-form-label">Contact Name</label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtContactName" CssClass="form-control" placeholder="Enter Contact Name" />
                <asp:RequiredFieldValidator  runat="server"  ID="rfvContactName" ControlToValidate="txtContactName" Display="Dynamic" ErrorMessage="Enter Contact Name" ForeColor="Red" ValidationGroup="Contact"/> 
            </div>
        </div>
        <div class="form-group row">
            <label for="txtAddress" class="col-md-2 col-form-label">Address</label>
            <div class="col-md-4">
                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" placeholder="Enter Address" TextMode="MultiLine" Rows="3" />
                <asp:RequiredFieldValidator  runat="server"  ID="rfvAddress" ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="Enter Address" ForeColor="Red" ValidationGroup="Contact"/> 
            </div>
            <label for="txtPincode" class="col-md-2 col-form-label">Pincode</label>
            <div class="col-md-4">
                <asp:TextBox runat="server" ID="txtPincode" CssClass="form-control" placeholder="Enter Pincode" />
                <asp:RequiredFieldValidator  runat="server"  ID="rfvPincode" ControlToValidate="txtPincode" Display="Dynamic" ErrorMessage="Enter Pincode" ForeColor="Red" ValidationGroup="Contact"/> 
            </div>
        </div>
        <div class="form-group row">
            <label for="txtEmailAddress" class="col-md-2 col-form-label">Email Address</label>
            <div class="col-md-4">
                <asp:TextBox runat="server" ID="txtEmailAddress" CssClass="form-control" placeholder="Enter Email Address" TextMode="Email" />
                <asp:RequiredFieldValidator  runat="server"  ID="rvfEmailAddress" ControlToValidate="txtEmailAddress" Display="Dynamic" ErrorMessage="Enter Email Address" ForeColor="Red" ValidationGroup="Contact"/> 
                <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ControlToValidate="txtEmailAddress" Display="Dynamic" ErrorMessage="Enter Valid Email Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
            <label for="txtMobileNo" class="col-md-2 col-form-label">Mobile No.</label>
            <div class="col-md-4">
                <asp:TextBox runat="server" ID="txtMobileNo" CssClass="form-control" placeholder="Enter Mobile No." MaxLength="10" TextMode="Phone" />
                <asp:RequiredFieldValidator  runat="server"  ID="rvfMobileNo" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Enter Mobile No." ForeColor="Red" ValidationGroup="Contact"/> 
                <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Enter Valid Mobile Number" ForeColor="Red" ValidationExpression="^([0-9]{10})$"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group row">
            <label for="ddlCountry" class="col-md-2 col-form-label">Coutry</label>
            <div class="col-md-4">
                <asp:dropDownList runat="server" ID="ddlCountry" CssClass="form-control" placeholder="Select Country" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                </asp:dropDownList>
                <asp:RequiredFieldValidator  runat="server"  ID="rvfCountry" ControlToValidate="ddlCountry" Display="Dynamic" ErrorMessage="Select Country" ForeColor="Red" ValidationGroup="Contact"/> 
            </div>
            <label for="ddlState" class="col-md-2 col-form-label">State</label>
            <div class="col-md-4">
                <asp:DropDownList runat="server" ID="ddlState" CssClass="form-control" placeholder="Select State" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator  runat="server"  ID="rvfState" ControlToValidate="ddlState" Display="Dynamic" ErrorMessage="Select State" ForeColor="Red" ValidationGroup="Contact"/> 
            </div>
        </div>
        <div class="form-group row">
            <label for="ddlCity" class="col-md-2 col-form-label">City</label>
            <div class="col-md-4">
                <asp:dropDownList runat="server" ID="ddlCity" CssClass="form-control" placeholder="Select City" AutoPostBack="True" >

                </asp:dropDownList>
                <asp:RequiredFieldValidator  runat="server"  ID="rvfCity" ControlToValidate="ddlCity" Display="Dynamic" ErrorMessage="Select City" ForeColor="Red" ValidationGroup="Contact"/> 
            </div>
            <label for="ddlContactCategory" class="col-md-2 col-form-label">ContactCategory</label>
            <div class="col-md-4">
                <asp:DropDownList runat="server" ID="ddlContactCategory" CssClass="form-control" placeholder="Select Contact Category" ></asp:DropDownList>
                <asp:RequiredFieldValidator  runat="server"  ID="rvfContactCategory" ControlToValidate="ddlContactCategory" Display="Dynamic" ErrorMessage="Select Contact Category" ForeColor="Red" ValidationGroup="Contact"/> 
            </div>
        </div>
        <div class="form-group row">
            <div class="col-md-10">
                <asp:Label ID="Label1" runat="server"  CssClass="alert-success" ForeColor="#00CC00" EnableViewState="false" />
            </div>
            <div class="col-md-2 pull-right">
                <asp:Button runat="server" ID="btnSave" Text="Save" ValidationGroup="Contact" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:HyperLink runat="server" ID="hlCancel" Text="Cancel" NavigateUrl="~/ContactList.aspx" CssClass="btn btn-danger "  />
                
            </div>
        </div>
    </div>
</asp:Content>
