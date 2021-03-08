using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

namespace ATM_Transections
{
    public partial class SendMoney : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Name"] != null)
                {
                    lblSenderName.Text = Session["Name"].ToString();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection objConn = new SqlConnection();
            objConn.ConnectionString = ConfigurationManager.ConnectionStrings["ATMConnectionString"].ConnectionString;
            try
            {
                objConn.Open();
                SqlTransaction sqlTransaction = objConn.BeginTransaction();
                try
                {
                    SqlCommand objCmd = new SqlCommand();
                    objCmd.Connection = objConn;
                    objCmd.Transaction = sqlTransaction;
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_SendMoney_UpdateByNameMobileNo";
                    objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    objCmd.Parameters.AddWithValue("@ReciverName", txtReciverName.Text.Trim());
                    objCmd.Parameters.AddWithValue("@ReciverMobileNo", txtReciverMobileNo.Text.Trim());
                    objCmd.Parameters.AddWithValue("@Balance", txtAmount.Text.Trim());
                    objCmd.Parameters.AddWithValue("@SenderName", Session["Name"].ToString());

                    objCmd.ExecuteNonQuery();
                    sqlTransaction.Commit();

                    lblMessage.Text = " Send Money Successfully  " + txtReciverName.Text.Trim();
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    ClearControl();
                }
                catch
                {
                    sqlTransaction.Rollback();
                    lblMessage.Text = "Check Details Or Insufficient Balance";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    
                }
            }
            catch (SqlException sqlex)
            {
                lblMessage.Text = sqlex.InnerException.Message.ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.InnerException.Message.ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            finally
            {
                if (objConn.State == ConnectionState.Open)
                    objConn.Close();
            }
        }

        private void ClearControl()
        {
            txtReciverName.Text = string.Empty;
            txtReciverMobileNo.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtReciverName.Focus();
        }
    }
}