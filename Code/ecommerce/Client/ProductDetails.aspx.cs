using eCommerce;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_ProductDetails : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ProductID"] != null)
        {
            FillDetailsByProductID(Convert.ToInt32(Request.QueryString["ProductID"]));
            this.Page.Title = "eCommers Products";
        }
        else
        {
            Response.Redirect("~/Client/Home.aspx");
        }
    }
    #endregion Page_Load

    #region FillDetailsByProductID
    private void FillDetailsByProductID(Int32 ProductID)
    {
        if (Request.QueryString["ProductID"] != null)
        {
            ENTProductMaster entProductMaster = new ENTProductMaster();
            BALProductMaster balProductMaster = new BALProductMaster();

            entProductMaster = balProductMaster.ProductMasterShowDetailsByPK(ProductID);

            if (!entProductMaster.ProductName.IsNull)
                lblProductName.Text = entProductMaster.ProductName.Value.ToString();

            if (!entProductMaster.ProductDetails.IsNull)
                lblDetail.Text = entProductMaster.ProductDetails.Value.ToString();
            
            if (!entProductMaster.ProductPrice.IsNull)
                lblPrice.Text = entProductMaster.ProductPrice.Value.ToString();
            
            if (!entProductMaster.ProductName.IsNull)
                lblProductName.Text = entProductMaster.ProductName.Value.ToString();

            if (!entProductMaster.ProductImage.IsNull)
                imgProduct.ImageUrl = entProductMaster.ProductImage.Value.ToString();
        }
    }
    #endregion FillDetailsByProductID

    #region AddToCart
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        BALProductOrder balProductOrder = new BALProductOrder();

        if (Request.QueryString["ProductID"] != null)
            balProductOrder.ProductOrderAddCart(Convert.ToInt32(Request.QueryString["ProductID"]));


        btnAddToCart.Visible = false;
    }
    #endregion AddToCart

}