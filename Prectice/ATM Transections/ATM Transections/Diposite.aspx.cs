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
    public partial class Diposite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDiposite.Focus();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ATMConnectionString"].ConnectionString;

            using (SqlConnection objConn = new SqlConnection(connStr))
            {
                objConn.Open();
                SqlTransaction sqlTransection = objConn.BeginTransaction();
                try
                {
                    SqlCommand objCmd = new SqlCommand();
                    objCmd.Connection = objConn;
                    objCmd.Transaction = sqlTransection;
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_DipositeAmount_Update";
                    objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    objCmd.Parameters.AddWithValue("@balance", txtDiposite.Text.Trim());

                    objCmd.ExecuteNonQuery();
                    sqlTransection.Commit();

                    lblMessage.Text = "Transection Successfully...";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    txtDiposite.Text = string.Empty;
                    txtDiposite.Focus();
                }
                catch
                {
                    sqlTransection.Rollback();
                    lblMessage.Text = "Transection Fail !";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
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