<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckPin.aspx.cs" Inherits="ATM_Transections.CheckPin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Check Pin</title>

    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="margin-top: 10%;">
            <h2>Check Pin</h2>
            <hr />
            <div class="form-group row">
                <label for="lblPin" class="col-sm-2 col-form-label">Enter Pin</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtPin" runat="server" class="form-control" placeholder="Enter Pin" MaxLength="4" />
                    <asp:RequiredFieldValidator ID="rfvPin" runat="server" ControlToValidate="txtPin" ErrorMessage="Enter Pin" ValidationExpression="^[0-9]{4}$" Display="Dynamic" ForeColor="Red" ValidationGroup="CheckPin" />
                    <asp:RegularExpressionValidator ID="revPin" runat="server" ControlToValidate="txtPin" ValidationExpression="[0-9]{4}" Display="Dynamic" ErrorMessage="Pin Must be 4 Digit" ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-10">
                    <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Submit" ValidationGroup="CheckPin" OnClick="btnSave_Click" />
                </div>
            </div>
            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
