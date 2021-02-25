﻿using System;
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
    public partial class CheckPin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection objConn = new SqlConnection();
            objConn.ConnectionString = ConfigurationManager.ConnectionStrings["ATMConnectionString"].ConnectionString.ToString();
            objConn.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_SelectByPin";
            objCmd.Parameters.AddWithValue("@Pin", txtPin.Text.Trim());
            SqlDataReader objSDR = objCmd.ExecuteReader();
            DataTable dtUser = new DataTable();
            dtUser.Load(objSDR);

            objConn.Close();

            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                foreach (DataRow drUser in dtUser.Rows)
                {
                    if (!drUser["Pin"].Equals(DBNull.Value))
                    {
                        Session["Pin"] = drUser["Pin"].ToString();
                    }
                    break;
                }
                Response.Redirect("~/BalanceEnquiry.aspx");
            }
            else
            {
                lblMessage.Text = "Incorrect Pin";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                txtPin.Focus();
            }
        }
    }
}