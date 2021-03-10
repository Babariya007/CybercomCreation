using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContactDetailsPrectice
{
    public partial class ContactDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGridview();
            }
            
        }

        #region FillGridView
        private void FillGridview()
        {
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactCS"].ConnectionString);
            objConn.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_SelectAll";

            SqlDataReader objSDR = objCmd.ExecuteReader();

            gvContact.DataSource = objSDR;
            gvContact.DataBind();

            objConn.Close();
        }
        #endregion FillGridView

        #region Delete Content
        private bool DeleteContact(Int32 ContactID)
        {
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactCS"].ConnectionString);
            objConn.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_DeleteByPK";
            objCmd.Parameters.AddWithValue("@ContactID", ContactID);

            objCmd.ExecuteNonQuery();
            objConn.Close();

            return true;
        }
        #endregion Delete Content

        protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DeleteRow" && e.CommandArgument != null)
                {
                    if (DeleteContact(Convert.ToInt32(e.CommandArgument)))
                    {
                        FillGridview();
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message.ToString();
            }
        }
    }
}