using eCommerce;
using Newtonsoft.Json;
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
    public string SelectAllDataByServerSide(int iDisplayLength, int iDisplayStart, int iSortCol_0, string sSortDir_0, string sSearch)
    {
        //HttpContext context = HttpContext.Current;
        //context.Response.ContentType = "aplication/json";

        int displayLength = iDisplayLength;
        int displayStart = iDisplayStart;
        int sortColumn = iSortCol_0;
        string sortDir = sSortDir_0;
        string search = sSearch;
        int filterCount = 0;

        List<ENTProductMaster> listProductMaster = new List<ENTProductMaster>();

        using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["eCommerceCS"].ConnectionString))
        {
            objConn.Open();
            using (SqlCommand objCmd = objConn.CreateCommand())
            {
                #region Prepare Command
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "PR_ProductMaster_SelectAllDataTable";
                objCmd.Parameters.AddWithValue("@DisplayLength", displayLength);
                objCmd.Parameters.AddWithValue("@DisplayStart", displayStart);
                objCmd.Parameters.AddWithValue("@SortColumn", sortColumn);
                objCmd.Parameters.AddWithValue("@SortDirection", sortDir);
                objCmd.Parameters.AddWithValue("@Search", search);
                #endregion Prepare Command

                using (SqlDataReader objSDR = objCmd.ExecuteReader())
                {

                    while (objSDR.Read())
                    {
                        ENTProductMaster entProductMaster = new ENTProductMaster();

                        if (!objSDR["ProductID"].Equals(DBNull.Value))
                        {
                            entProductMaster.ProductID = Convert.ToInt32(objSDR["ProductID"]);
                        }
                        if (!objSDR["TotalCount"].Equals(DBNull.Value))
                        {
                            filterCount = Convert.ToInt32(objSDR["TotalCount"]);
                        }
                        if (!objSDR["ProductName"].Equals(DBNull.Value))
                        {
                            entProductMaster.ProductName = Convert.ToString(objSDR["ProductName"]);
                        }
                        if (!objSDR["ProductQuantity"].Equals(DBNull.Value))
                        {
                            entProductMaster.ProductQuantity = Convert.ToInt32(objSDR["ProductQuantity"]);
                        }
                        if (!objSDR["ProductDetails"].Equals(DBNull.Value))
                        {
                            entProductMaster.ProductDetails = Convert.ToString(objSDR["ProductDetails"]);
                        }
                        if (!objSDR["ProductPrice"].Equals(DBNull.Value))
                        {
                            entProductMaster.ProductPrice = Convert.ToDecimal(objSDR["ProductPrice"]);
                        }
                        if (!objSDR["ProductImage"].Equals(DBNull.Value))
                        {
                            entProductMaster.ProductImage = Convert.ToString(objSDR["ProductImage"]);
                        }
                        listProductMaster.Add(entProductMaster);
                    }
                }
            }
        }

        var result = new
        {
            iTotalRecords = GetTotalProduct(),
            iTotalDisplayRecords = filterCount,
            aaData = listProductMaster
        };
        string jsonData = JsonConvert.SerializeObject(result);
        return jsonData;
    }
    private int GetTotalProduct()
    {
        int totalProductCount = 0;
        using (SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["eCommerceCS"].ConnectionString))
        {
            objConn.Open();
            SqlCommand objCmd = new SqlCommand("Select count(*) from ProductMaster", objConn);
            totalProductCount = (int)objCmd.ExecuteScalar();
        }
        return totalProductCount;
    }

}
