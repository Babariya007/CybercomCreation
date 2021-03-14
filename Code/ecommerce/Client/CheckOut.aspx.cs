using eCommerce;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_CheckOut : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    #endregion Page_Load

    #region btnSave_Click
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ENTCustomer entCustomer = new ENTCustomer();
        BALCustomer balCustomer = new BALCustomer();

        if (txtFirstName.Text.Trim() != String.Empty)
            entCustomer.FirstName = Convert.ToString(txtFirstName.Text.Trim());

        if (txtLastName.Text.Trim() != String.Empty)
            entCustomer.LastName = Convert.ToString(txtLastName.Text.Trim());

        if (txtAddress.Text.Trim() != String.Empty)
            entCustomer.Address = Convert.ToString(txtAddress.Text.Trim());

        entCustomer.OrderQuentity = Convert.ToInt32(Session["TotalQuantity"]);

        entCustomer.TotalBill = Convert.ToDecimal(Session["TotalBill"]);

        balCustomer.Insert(entCustomer);

        #region Download pdf
        StringBuilder sb = new StringBuilder();
        sb.Append("Name : " + txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim() + "\n");
        sb.Append("Address : " + txtAddress.Text.Trim() + "\n\n\n");
      
        BALProductMaster balProductMaster = new BALProductMaster();
        DataTable dt = balProductMaster.GetProductNamePriceSelectAll();

        if (dt != null && dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("Product Name : " + dr["ProductName"].ToString() + "\n");
                sb.Append("Product Price: " + dr["ProductPrice"].ToString() + "\n\n");
            }
        }

        sb.Append("Total Quantity : " + Session["TotalQuantity"].ToString() + "\n");
        sb.Append("18% GST Charge : " + Session["GSTCharge"].ToString() + "\n\n");
        sb.Append("Total Bill : " + Session["TotalBill"].ToString() + "\n");


        Response.Clear();
        Response.ContentType = "application/txt";
        Response.Buffer = true;
        Response.AppendHeader("content-disposition", "attachement;filename=ProductBill.txt");
        Response.BinaryWrite(Encoding.UTF8.GetBytes(sb.ToString()));

        ClearControl();
        Response.End();
        #endregion Download pdf

    }
    #endregion btnSave_Click

    #region ClearControl
    private void ClearControl()
    {
        txtFirstName.Text = string.Empty;
        txtLastName.Text = string.Empty;
        txtAddress.Text = string.Empty;
        Session.Clear();
        txtFirstName.Focus();
    }
    #endregion ClearControl

}