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
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtName.Focus();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection objConn = new SqlConnection();
                objConn.ConnectionString = ConfigurationManager.ConnectionStrings["ATMConnectionString"].ConnectionString;
                objConn.Open();

                SqlCommand objCmd = new SqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_User_Insert";

                objCmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                objCmd.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text.Trim());
                objCmd.Parameters.AddWithValue("@Pin", txtPin.Text.Trim());
                objCmd.Parameters.AddWithValue("@Balance", txtDiposite.Text.Trim());

                objCmd.ExecuteNonQuery();

                lblMessage.Text = "Create Account Successfully...";
                lblMessage.ForeColor = System.Drawing.Color.Green;

                txtName.Text = string.Empty;
                txtMobileNo.Text = string.Empty;
                txtPin.Text = string.Empty;
                txtDiposite.Text = string.Empty;
                txtName.Focus();

                objConn.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.InnerException.Message.ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}