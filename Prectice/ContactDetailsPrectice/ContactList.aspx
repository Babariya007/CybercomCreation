<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.Master" AutoEventWireup="true" CodeBehind="ContactList.aspx.cs" Inherits="ContactDetailsPrectice.ContactDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Contact List</h2>
        <hr />
        <div style="text-align: right;">
            <asp:HyperLink ID="hlAdd" runat="server" Text="Add New" NavigateUrl="~/ContactAddEdit.aspx" CssClass="btn btn-primary"></asp:HyperLink>
        </div>
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <div class="row">
            <div class="col-md-12">
                <br />

                <asp:GridView ID="gvContact" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover table-responsive" OnRowCommand="gvContact_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Edit Contact">
                            <ItemTemplate>
                                <div style="text-align: center">
                                    <asp:HyperLink runat="server" ID="hledit" CssClass="btn btn-primary" NavigateUrl='<%# "~/ContactAddEdit.aspx?ContactId=" + Eval("ContactId").ToString().Trim() %>'>Edit</asp:HyperLink>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete Contact">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" CommandArgument='<%#Eval("ContactID") %>' CommandName="DeleteRow" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ContactId" HeaderText="Contact ID" />
                        <asp:BoundField DataField="ContactName" HeaderText="Contact Name" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="Pincode" HeaderText="Pincode" />
                        <asp:BoundField DataField="Email" HeaderText="Email Id" />
                        <asp:BoundField DataField="MobileNumber" HeaderText="Mobile No" />
                        <asp:BoundField DataField="CityName" HeaderText="City Name" />
                        <asp:BoundField DataField="StateName" HeaderText="State Name" />
                        <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                        <asp:BoundField DataField="ContactCategoryName" HeaderText="ContactCategory" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
