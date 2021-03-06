<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TxtAutoComplete.aspx.cs" Inherits="AutoComplete.TxtAutoComplete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="js/jquery-ui.structure.css" rel="stylesheet" />

    <script src="js/external/jquery/jquery.js"></script>
    <script src="js/jquery-ui.js"></script>
    <script src="js/jquery-ui.min.js"></script>

    <script type="text/javascript">  
        $(document).ready(
            function () {
            $('#txtCustomerName').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "TxtAutoComplete.aspx/GetCustomerName",
                        data: "{'customerName':'" + document.getElementById('txtCustomerName').value + "'}",
                        dataType: "json",
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (data) {
                            alert("No Match");
                        }
                    });
                }
            });

        });
    </script>


</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellpadding="10" cellspacing="10" style="border: solid 5px Green; background-color: SkyBlue;"
                width="50%" align="center">
                <tr>
                    <td>
                        <span style="color: Red; font-weight: bold; font-size: 18pt;">Enter Customer Name:</span>
                        <asp:TextBox ID="txtCustomerName" runat="server" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
