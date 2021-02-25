<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="ATM_Transections.CreateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create New Account</title>

    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous" />

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous" />

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="container" style="margin-top: 10%;">
            <h2>Create New Account</h2>
            <hr />
            <div class="form-group row">
                <label for="lblName" class="col-sm-2 col-form-label">Enter Name</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="Enter Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Enter Name" Display="Dynamic" ForeColor="Red" ValidationGroup="CreateAccount" />

                </div>
            </div>
            <div class="form-group row">
                <label for="lblMobileNo" class="col-sm-2 col-form-label">Enter Mobile No</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" placeholder="Enter Mobile No" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="Enter Mobile No" Display="Dynamic" ForeColor="Red" ValidationGroup="CreateAccount" />
                    <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ControlToValidate="txtMobileNo" ValidationExpression="[0-9]{10}" Display="Dynamic" ErrorMessage="Please Enter Valid Mobile No" ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-group row">
                <label for="lblPin" class="col-sm-2 col-form-label">Enter Pin</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtPin" runat="server" class="form-control" placeholder="Enter Pin" MaxLength="4"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPin" runat="server" ControlToValidate="txtPin" ErrorMessage="Enter Pin" Display="Dynamic" ForeColor="Red" ValidationGroup="CreateAccount" />
                    <asp:RegularExpressionValidator ID="revPin" runat="server" ControlToValidate="txtPin" ValidationExpression="[0-9]{4}" Display="Dynamic" ErrorMessage="Pin Must be 4 Digit" ForeColor="Red"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="form-group row">
                <label for="lblDepositeAmount" class="col-sm-2 col-form-label">Enter Diposite Amount</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtDiposite" runat="server" class="form-control" placeholder="Minimum Amount 10000"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDiposite" runat="server" ControlToValidate="txtDiposite" ErrorMessage="Enter Deposite Amount" Display="Dynamic" ForeColor="Red" ValidationGroup="CreateAccount" />
                    <asp:RangeValidator ID="rvDiposite" runat="server" MinimumValue="1000" MaximumValue="9999999999" ControlToValidate="txtDiposite" ErrorMessage="Amount Must be More then 1000" ForeColor="Red" ValidationGroup="CreateAccount"></asp:RangeValidator>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-10">
                    <asp:Button ID="btnSave" runat="server" class="btn btn-primary" Text="Save" OnClick="btnSave_Click" ValidationGroup="CreateAccount"  />
                    <asp:HyperLink ID="hlCancle" runat="server" class="btn btn-danger" Text="Cancle" NavigateUrl="~/WelcomePage.aspx"/>

                </div>
            </div>
            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
