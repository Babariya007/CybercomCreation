using eCommerce;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ProductList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillProductGridView();
        }
    }

    #region FillRegularOrderGridView

    private void FillProductGridView()
    {
        BALProductMaster balProductMaster = new BALProductMaster();
        DataTable dtProductMaster = balProductMaster.SelectAll();
        if (dtProductMaster != null && dtProductMaster.Rows.Count > 0)
        {
            gvProduct.DataSource = dtProductMaster;
            gvProduct.DataBind();
            gvProduct.UseAccessibleHeader = true;
            gvProduct.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    #endregion FillRegularOrderGridView

    #region gvProduct_RowCommand
    protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
            {
                BALProductMaster balProductMaster = new BALProductMaster();
                if (balProductMaster.Delete(Convert.ToInt32(e.CommandArgument)))
                {
                    FillProductGridView();
                }
                else
                {
                    lblError.Text = balProductMaster.Message;
                    lblError.ForeColor = Color.Red;
                }
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message.ToString();
            lblError.ForeColor = Color.Red;
        }
    }
    #endregion gvProduct_RowCommand

}