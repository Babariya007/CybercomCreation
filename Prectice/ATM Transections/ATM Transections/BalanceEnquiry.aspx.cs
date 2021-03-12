using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATM_Transections
{
    public partial class BalanceEnquiry : System.Web.UI.Page
    {
        #region Page_Load
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
        #endregion Page_Load

        #region GetBalance
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
        #endregion GetBalance

        #region GetBalanceEnquiry
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
        #endregion GetBalanceEnquiry

        #region Download Statement
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["ATMConnectionString"].ConnectionString;
            using (SqlConnection objConn = new SqlConnection(conStr))
            {
                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_DowanloadStatement_SelectByDate";
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                objCmd.Parameters.AddWithValue("@FromDate", txtFromDate.Text);
                objCmd.Parameters.AddWithValue("@ToDate", txtToDate.Text);
                objConn.Open();

                using (SqlDataAdapter objSDA = new SqlDataAdapter(objCmd))
                {
                    DataSet ds = new DataSet();
                    objSDA.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        
                        sb.Append("Account Holder Name : " + Session["Name"] + "\n");
                        sb.Append("Statement Between " + txtFromDate.Text + " To " + txtToDate.Text + "\n\n");

                        foreach (DataRow dataRow in ds.Tables[0].Rows)
                        {
                            sb.Append(dataRow[0] + " \t" + dataRow[1] + " \t" + Convert.ToDateTime(dataRow[2]).ToString("dd MMMM yyyy hh:mm:ss tt") + "\n");
                        }

                        Response.Clear();
                        Response.ContentType = "application/txt";
                        Response.Buffer = true;
                        Response.AppendHeader("content-disposition", "attachement;filename=" + Session["Name"] + "Statement.txt");
                        Response.BinaryWrite(Encoding.UTF8.GetBytes(sb.ToString()));
                        Response.End();
                        Response.Flush();
                    }
                }
            }
        }
        #endregion Download Statement

    }
}