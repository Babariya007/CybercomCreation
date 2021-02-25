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

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ATMConnectionString"].ConnectionString.ToString();

            using (SqlConnection objConn = new SqlConnection(connStr))
            {
                SqlTransaction sqlTransection = objConn.BeginTransaction();
                try
                {
                    objConn.Open();
                    SqlCommand objCmd = new SqlCommand();
                    objCmd.Connection = objConn;
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_DipositeAmount_Update";
                    objCmd.Parameters.AddWithValue("@Pin", Convert.ToInt32(Session["Pin"]));
                    objCmd.Parameters.AddWithValue("@balance", txtDiposite.Text.Trim());

                    objCmd.ExecuteNonQuery();
                    sqlTransection.Commit();
                    objConn.Close();

                    lblMessage.Text = "Transection Successfully...";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                catch
                {
                    sqlTransection.Rollback();
                    lblMessage.Text = "Transection Fail !";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}