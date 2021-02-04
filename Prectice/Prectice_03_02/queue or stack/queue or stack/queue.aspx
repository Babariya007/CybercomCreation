<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="queue.aspx.cs" Inherits="queue_or_stack.queue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table style="border: 1px solid; text-align: center">
            <tr>
                <td><b>Counter 1</b></td>
                <td><b>Counter 2</b></td>
                <td><b>Counter 3</b></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtCounter1" runat="server" BackColor="#6699FF" ForeColor="White"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtCounter2" runat="server" BackColor="#6699FF" ForeColor="White"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtCounter3" runat="server" BackColor="#6699FF" ForeColor="White"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnCounter1" runat="server" Text="Button" Width="160px" OnClick="btnCounter1_Click" />
                </td>
                <td>
                    <asp:Button ID="btnCounter2" runat="server" Text="Button" Width="160px" OnClick="btnCounter2_Click" />
                </td>
                <td>
                    <asp:Button ID="btnCounter3" runat="server" Text="Button" Width="160px" OnClick="btnCounter3_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:TextBox ID="txtDisplay" runat="server" BackColor="#009933" Width="497px" ForeColor="White"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:ListBox ID="listToken" runat="server" Width="100px"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="btnPrintToken" runat="server" Text="Print Token" OnClick="btnPrintToken_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
