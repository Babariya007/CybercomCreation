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
        if (Request.QueryString["ProductID"] != null)
        {
            Session["ProductID"] = Request.QueryString["ProductID"];
        }
        //else
        //{
        //    Response.Redirect("~/Client/Home.aspx");
        //}
    }
    #endregion Page_Load

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ENTCustomer entCustomer = new ENTCustomer();
        BALCustomer balCustomer = new BALCustomer();

        if (Session["ProductName"] != null)
        {
            if (txtFirstName.Text.Trim() != String.Empty)
                entCustomer.FirstName = Convert.ToString(txtFirstName.Text.Trim());

            if (txtLastName.Text.Trim() != String.Empty)
                entCustomer.LastName = Convert.ToString(txtLastName.Text.Trim());

            if (txtAddress.Text.Trim() != String.Empty)
                entCustomer.Address = Convert.ToString(txtAddress.Text.Trim());

            entCustomer.ProductID = Convert.ToInt32(Session["ProductID"]);

            entCustomer.OrderQuentity = Convert.ToInt32(Session["Quantity"]);

            entCustomer.TotalBill = Convert.ToDecimal(Session["TotalBill"]);

            balCustomer.Insert(entCustomer);

            #region Download pdf
            StringBuilder sb = new StringBuilder();
            sb.Append("Name : " + txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim() + "\n");
            sb.Append("Address : " + txtAddress.Text.Trim() + "\n\n\n");
            sb.Append("Product Name : " + Session["ProductName"].ToString() + "\n");
            sb.Append("Product Price: " + Session["ProductPrice"].ToString() + "\n");
            sb.Append("Quantity : " + Session["Quantity"].ToString() + "\n");
            sb.Append("18% GST Charge : " + Session["GSTCharge"].ToString() + "\n\n");
            sb.Append("Total Bill : " + Session["TotalBill"].ToString() + "\n");


            Response.Clear();
            Response.ContentType = "application/txt";
            Response.Buffer = true;
            Response.AppendHeader("content-disposition", "attachement;filename=" + Session["ProductName"] + " Bill.txt");
            Response.BinaryWrite(Encoding.UTF8.GetBytes(sb.ToString()));

            ClearControl();
            Response.End();
            #endregion Download pdf

            

        }
        else
        {
            Response.Redirect("~/Client/Home.aspx");
        }
    }

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