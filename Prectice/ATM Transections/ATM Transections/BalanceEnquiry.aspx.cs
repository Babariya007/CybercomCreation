using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
            GetBalanceEnquiry();
            GetBalance();
        }

        private void GetBalance()
        {
            string conStr = ConfigurationManager.ConnectionStrings["ATMConnectionString"].ConnectionString;
            using (SqlConnection objConn = new SqlConnection(conStr))
            {
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_ShowBalance_SelectByUserID";
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                objConn.Open();

                SqlDataReader objSDR = objCmd.ExecuteReader();
                if (objSDR.HasRows == true)
                {
                    while (objSDR.Read() == true)
                    {
                        lblBalance.Text = "Your Current Balance is " + objSDR["Balance"].ToString();
                        lblBalance.ForeColor = Color.Green;
                        lblBalance.Font.Bold = true;
                    }
                }
            }
        }

        private void GetBalanceEnquiry()
        {
            string conStr = ConfigurationManager.ConnectionStrings["ATMConnectionString"].ConnectionString;
            using (SqlConnection objConn = new SqlConnection(conStr))
            {
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_BalanceInquiry_SelectByUserID";
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                objConn.Open();

                DataTable dt = new DataTable();
                using (SqlDataReader objSDR = objCmd.ExecuteReader())
                {
                    dt.Load(objSDR);
                }

                gvTransectionHistory.DataSource = dt;
                gvTransectionHistory.DataBind();
            }
        }


        //protected void gvTransectionHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    foreach (GridViewRow row in gvTransectionHistory.Rows)
        //    {
        //        for (int i = 0; i < gvTransectionHistory.Columns.Count; i++)
        //        {
        //            TableCell cell = row.Cells[i];
        //            int balance = int.Parse(cell.Text);
        //            if (balance <= 0)
        //            {
        //                cell.ForeColor = Color.Red;
        //            }
        //            else
        //            { 
        //                cell.ForeColor = Color.Green;
        //            }
        //        }
        //    }
        //}

    }
}