using eCommerce;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillProductRepeaterView();
        }
    }

    private void FillProductRepeaterView()
    {
        ENTProductMaster entProductMaster = new ENTProductMaster();
        BALProductMaster balProductMaster = new BALProductMaster();

        DataTable dt = balProductMaster.SelectAll();
        if (dt.Rows.Count > 0)
        {
            rpProducts.DataSource = dt;
            rpProducts.DataBind();
        }
    }
}