using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATM_Transections
{
    public partial class UserMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Pin"] == null)
                {
                    Response.Redirect("~/WelcomePage.aspx");
                }
            }
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/WelcomePage.aspx");
        }
    }
}