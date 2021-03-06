using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AutoComplete
{
    public partial class TxtAutoComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetCustomerName(txtCustomerName.Text);
        }

        [WebMethod, ScriptMethod]
        public static List<string> GetCustomerName(string customerName)
        {
            List<string> customerResult = new List<string>();
            string conStr = ConfigurationManager.ConnectionStrings["AutoCompletetxt"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "PR_Customer_Show";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                con.Open();
                cmd.Parameters.AddWithValue("@CustomerName", customerName);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    customerResult.Add(dr["CustomerName"].ToString());
                }
                con.Close();
                return customerResult;
            }
        }

    }
}