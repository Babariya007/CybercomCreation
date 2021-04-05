using eCommerce;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

/// <summary>
/// Summary description for ProductService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class ProductService : System.Web.Services.WebService
{

    public ProductService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void Product()
    {
        List<ENTProductMaster> listProductMaster = new List<ENTProductMaster>();

        using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["eCommerceCS"].ConnectionString))
        {
            objConn.Open();
            using (SqlCommand objCmd = objConn.CreateCommand())
            {
                #region Prepare Command
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_ProductMaster_SelectAll";
                #endregion Prepare Command


                using (SqlDataReader objSDR = objCmd.ExecuteReader())
                {

                    while (objSDR.Read())
                    {
                        ENTProductMaster entProductMaster = new ENTProductMaster();

                        entProductMaster.ProductID = Convert.ToInt32(objSDR["ProductID"]);

                        entProductMaster.ProductName = Convert.ToString(objSDR["ProductName"]);

                        entProductMaster.ProductQuantity = Convert.ToInt32(objSDR["ProductQuantity"]);

                        entProductMaster.ProductDetails = Convert.ToString(objSDR["ProductDetails"]);

                        entProductMaster.ProductPrice = Convert.ToDecimal(objSDR["ProductPrice"]);

                        entProductMaster.ProductImage = Convert.ToString(objSDR["ProductImage"]);

                        listProductMaster.Add(entProductMaster);

                    }
                }
            }
        }
        var js = new JavaScriptSerializer();
        Context.Response.Write(js.Serialize(listProductMaster));
    }

}
