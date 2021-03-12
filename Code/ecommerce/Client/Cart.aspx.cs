using eCommerce;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_Cart : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDetailsByProductID();
            GSTANDTotalBill();
        }
    }
    #endregion Page_Load

    #region LoadControls
    private void FillDetailsByProductID()
    {
        ENTProductMaster entProductMaster = new ENTProductMaster();
        BALProductMaster balProductMaster = new BALProductMaster();

        DataTable dt = balProductMaster.ItemInCartByID();
        if(dt.Rows.Count > 0)
        {
            rpCart.DataSource = dt;
            rpCart.DataBind();
        }
    }

    #endregion LoadControls

    #region CalGST
    //private void CalGST()
    //{
    //    Double GSTCharge = 0;

    //    foreach(RepeaterItem item in rpCart.Items)
    //    {
    //        TextBox txtQuantity = (TextBox)item.FindControl("txtQuantity");
    //        lblQuantity.Text = txtQuantity.Text;

    //        Label lblPrice = (Label)item.FindControl("lblPrice");
    //        GSTCharge += (Convert.ToDouble(lblPrice.Text) * Convert.ToDouble(txtQuantity.Text)) * 0.18;
    //    }

    //    lblGSTCharge.Text = GSTCharge.ToString();
    //}
    #endregion CalGST

    #region CalTotalBill
    //private void CalTotalBill()
    //{
    //    Double Amount = Convert.ToDouble(lblProductPrice.Text) * Convert.ToDouble(txtQuantity.Text);
    //    Double TotalAmount = Amount + Convert.ToDouble(lblGSTCharge.Text);
    //    lblTotalBill.Text = TotalAmount.ToString();
    //}
    #endregion CalTotalBill

    private void GSTANDTotalBill()
    {
        Double GSTCharge = 0;
        Double Amount = 0;
        Double TotalAmount = 0;
        Int32 TotalQuantity = 0;

        foreach (RepeaterItem item in rpCart.Items)
        {
            TextBox txtQuantity = (TextBox)item.FindControl("txtQuantity");
            TotalQuantity += Convert.ToInt32(txtQuantity.Text);

            Label lblPrice = (Label)item.FindControl("lblPrice");
            GSTCharge += (Convert.ToDouble(lblPrice.Text) * Convert.ToDouble(txtQuantity.Text)) * 0.18;

            Amount += (Convert.ToDouble(lblPrice.Text) * Convert.ToDouble(txtQuantity.Text));
        }

        TotalAmount = (Convert.ToDouble(Amount) + Convert.ToDouble(GSTCharge));
        lblQuantity.Text = TotalQuantity.ToString();
        lblTotalBill.Text = TotalAmount.ToString();
        lblGSTCharge.Text = GSTCharge.ToString();
    }

    #region txtQuantity_TextChanged
    protected void txtQuantity_TextChanged(object sender, EventArgs e)
    {
        //if (Convert.ToInt32(txtQuantity.Text) <= Convert.ToInt32(Session["ProductQuantity"]))
        //{
        GSTANDTotalBill();
        //    CalTotalBill();
        //    lblError.Visible = false;
        //}
        //else
        //{
        //    lblError.Visible = true;
        //    lblError.Text = "You enter to Much Quantity. Stock not available Please Decress Quantity";
        //    lblError.ForeColor = Color.Red;
        //}
    }
    #endregion txtQuantity_TextChanged

    #region Button Checkout
    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        //Session["ProductName"] = lblProductName.Text.ToString();
        //Session["ProductPrice"] = lblProductPrice.Text.ToString();
        //Session["Quantity"] = lblQuantity.Text.ToString();
        //Session["GSTCharge"] = lblGSTCharge.Text.ToString();
        //Session["TotalBill"] = lblTotalBill.Text.ToString();

        //Response.Redirect("~/Client/CHeckOut.aspx?ProductID=" + Request.QueryString["ProductID"]);
    }
    #endregion Button Checkout

}