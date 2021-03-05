<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecaptchaTesting.aspx.cs" Inherits="Recaptcha.Recaptcha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://www.google.com/recaptcha/api.js" async defer></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        Enter Name : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv" ControlToValidate="txtName" runat="server" ErrorMessage="Enter Name" ForeColor="Red" ValidationGroup="Recaptcha"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="g-recaptcha" data-type="image" data-sitekey="6Len3XIaAAAAAHG33KuVdyZPpwDQTbIFnZD5rUSN">
                        <%--<asp:RequiredFieldValidator ID="rfvlbl" runat="server" ControlToValidate="lblCaptcha" ErrorMessage="Check Recaptcha" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnClick" runat="server" Text="Submit" ValidationGroup="Recaptcha" OnClick="btnClick_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
