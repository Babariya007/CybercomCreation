using eCommerce;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_OrderList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillOrderListGridView();
        }
    }

    #region FillRegularOrderGridView

    private void FillOrderListGridView()
    {
        BALCustomer balOrderList = new BALCustomer();
        DataTable dtOrderList = balOrderList.SelectAll();
        if (dtOrderList != null && dtOrderList.Rows.Count > 0)
        {
            gvOrderList.DataSource = dtOrderList;
            gvOrderList.DataBind();
        }
    }

    #endregion FillRegularOrderGridView
}