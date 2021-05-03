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
            FillDetailsItemInCart();
            GSTANDTotalBill();
        }
    }
    #endregion Page_Load

    #region LoadControls
    private void FillDetailsItemInCart()
    {
        ENTCart entProductMaster = new ENTCart();
        BALCart balProductMaster = new BALCart();

        DataTable dt = balProductMaster.ItemInCart();
        if (dt.Rows.Count > 0)
        {
            rpCart.DataSource = dt;
            rpCart.DataBind();
        }
        else
        {
            rpCart.Visible = false;
            lblGSTCharge.Visible = false;
            lblQuantity.Visible = false;
            lblTotalBill.Visible = false;
            btnCheckOut.Visible = false;
        }
    }

    #endregion LoadControls

    #region GSTANDTotalBill
    private void GSTANDTotalBill()
    {
        Double GSTCharge = 0;
        Double Amount = 0;
        Double TotalAmount = 0;
        Int32 TotalQuantity = 0;

        foreach (RepeaterItem item in rpCart.Items)
        {
            HiddenField hfProductID = (HiddenField)item.FindControl("hfProductID");
            List<int> productList = new List<int>();
            productList.Add(Convert.ToInt32(hfProductID.Value));
            Session["ProductID"] = productList;

            TextBox txtQuantity = (TextBox)item.FindControl("txtQuantity");
            TotalQuantity += Convert.ToInt32(txtQuantity.Text);
            List<int> quantityList = new List<int>();
            quantityList.Add(Convert.ToInt32(txtQuantity.Text));
            Session["ProductQuantity"] = quantityList;

            Label lblPrice = (Label)item.FindControl("lblPrice");
            GSTCharge += (Convert.ToDouble(lblPrice.Text) * Convert.ToDouble(txtQuantity.Text)) * 0.18;

            Amount += (Convert.ToDouble(lblPrice.Text) * Convert.ToDouble(txtQuantity.Text));
        }

        TotalAmount = (Convert.ToDouble(Amount) + Convert.ToDouble(GSTCharge));
        lblQuantity.Text = "Total Quantity : " + TotalQuantity.ToString();
        lblGSTCharge.Text = "Total GST Charge : " + GSTCharge.ToString();
        lblTotalBill.Text = "Total Bill : " + TotalAmount.ToString();

        Session["TotalQuantity"] = TotalQuantity.ToString();
        Session["GSTCharge"] = GSTCharge.ToString();
        Session["TotalBill"] = TotalAmount.ToString();
    }
    #endregion GSTANDTotalBill

    #region txtQuantity_TextChanged
    protected void txtQuantity_TextChanged(object sender, EventArgs e)
    {
        GSTANDTotalBill();
    }
    #endregion txtQuantity_TextChanged

    #region Button Checkout
    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Client/CHeckOut.aspx");
    }
    #endregion Button Checkout

    #region rpCart_ItemCommand
    protected void rpCart_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            BALCart balCart = new BALCart();
            if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
            {
                if (balCart.Delete(Convert.ToInt32(e.CommandArgument)))
                {
                    FillDetailsItemInCart();
                }
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.InnerException.Message.ToString();
            lblError.ForeColor = Color.Red;
        }
    }
    #endregion rpCart_ItemCommand

}