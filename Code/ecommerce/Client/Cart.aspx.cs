using eCommerce;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
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
            if (Request.QueryString["ProductID"] != null)
            {
                FillDetailsByProductID(Convert.ToInt32(Request.QueryString["ProductID"]));
                this.Page.Title = "Cart eCommers Products";
            }
            else 
            {
                Response.Clear();
                Response.Redirect("~/Client/Home.aspx");
            }
        }
    }
    #endregion Page_Load

    #region LoadControls
    private void FillDetailsByProductID(SqlInt32 ProductID)
    {
        ENTProductMaster entProductMaster = new ENTProductMaster();
        BALProductMaster balProductMaster = new BALProductMaster();

        if (Request.QueryString["ProductID"] != null)
        {
            entProductMaster.ProductID = ProductID;
        }

        DataTable dt = balProductMaster.ItemInCartByID(ProductID);
        if (dt.Rows.Count > 0)
        {
            rpCheckout.DataSource = dt;
            rpCheckout.DataBind();
        }

        //if (!entProductMaster.ProductImage.IsNull)
        //    FuUpload.ImageUrl = entProductMaster.ProductImage.Value.ToString();

    }

    #endregion LoadControls

    //private void CalGST()
    //{
    //    Double GSTCharge;

    //    GSTCharge = Convert.ToDouble(lblProductPrice.Text) * Convert.ToDouble(txtQuantity.Text);

    //    lblGSTCharge.Text = GSTCharge.ToString();
    //}

    protected void txtQuantity_TextChanged(object sender, EventArgs e)
    {
        //CalGST();
    }
}