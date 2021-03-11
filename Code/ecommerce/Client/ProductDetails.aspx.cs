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
    }
    #endregion Page_Load

    #region FillDetailsByProductID
    private void FillDetailsByProductID(Int32 ProductID)
    {
        if (Request.QueryString["ProductID"] != null)
        {
            ENTProductMaster entProductMaster = new ENTProductMaster();
            BALProductMaster balProductMaster = new BALProductMaster();

            if (Request.QueryString["ProductID"] != null)
            {
                entProductMaster.ProductID = ProductID;
            }

            DataTable dt = balProductMaster.ProductDetailsByID(ProductID);
            if (dt.Rows.Count > 0)
            {
                rpProductDetails.DataSource = dt;
                rpProductDetails.DataBind();
            }
        }
    }
    #endregion FillDetailsByProductID

}