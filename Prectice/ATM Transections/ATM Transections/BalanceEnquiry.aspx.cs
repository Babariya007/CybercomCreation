using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATM_Transections
{
    public partial class BalanceEnquiry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Name"] != null)
                {
                    lblUserName.Text = Session["Name"].ToString();
                }
            }
        }
    }
}