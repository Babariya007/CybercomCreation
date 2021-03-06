using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AutoComplete
{
    /// <summary>
    /// Summary description for Customer
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Customer : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetCustomerName(string customerName)
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
