<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.Master" AutoEventWireup="true" CodeBehind="BalanceEnquiry.aspx.cs" Inherits="ATM_Transections.BalanceEnquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="<%=ResolveClientUrl("~/css/Style.css")%>" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>
            <asp:Label ID="lblUserName" runat="server"></asp:Label></h2>
        <hr />
        <div>
            <h4>Balance Enquiry</h4>
            <asp:Label ID="lblBalance" runat="server" Font-Size="Large"></asp:Label>
        </div>
        <br />
        <br />

        <div class="row">
            <div class="form-group row" style="margin-left: 5px">
                <label for="lblPin" class="col-sm-2 col-form-label">Download Statement</label>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtFromDate" runat="server" class="form-control" type="date" />
                </div>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtToDate" runat="server" class="form-control" type="date" />
                </div>
                <div class="col-sm-3">
                    <asp:Button ID="btnDownload" runat="server" class="btn btn-primary" Text="Download" OnClick="btnDownload_Click" />
                </div>
            </div>
        </div>
        <br />
        <br />
        <div>
            <asp:GridView ID="gvTransectionHistory" runat="server" AutoGenerateColumns="False" CssClass="table table-borderless" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="Sr No">
                        <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TransectionMessage" HeaderText="Transection" />
                    <asp:TemplateField HeaderText="Payment" ItemStyle-Font-Bold="true">
                        <ItemTemplate>
                            <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount")%>' CssClass='<%# ATM_Transections.ChangeColor.RedOrGreen(Convert.ToInt32(Eval("Amount"))) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField DataField="Amount" HeaderText="Amount" />--%>
                    <asp:BoundField DataField="Date" HeaderText="Date" />

                </Columns>
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
            </asp:GridView>
        </div>
    </div>

</asp:Content>
