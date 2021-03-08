using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATM_Transections
{
    public partial class Withdrawal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtWithdrowal.Focus();
            }
        }

        

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ATMConnectionString"].ConnectionString.ToString();

            using (SqlConnection objConn = new SqlConnection(connStr))
            {
                objConn.Open();
                
                try
                {
                    SqlCommand objCmd = new SqlCommand();
                    objCmd.Connection = objConn;
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_WithdrowalAmount_Update";
                    objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    objCmd.Parameters.AddWithValue("@balance", txtWithdrowal.Text);

                    objCmd.ExecuteNonQuery();

                    lblMessage.Text = "Transection Successfully...";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    txtWithdrowal.Text = string.Empty;
                    txtWithdrowal.Focus();
                }
                catch (SqlException sqlex)
                {
                    if (sqlex.Number == 501)
                    {
                        lblMessage.Text = "Insufficient Balance";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblMessage.Text = "Transection Fail !";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                finally
                { 
                    if(objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }

        }
    }
}