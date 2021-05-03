using eCommerce;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ProductList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //gvProduct.UseAccessibleHeader = true;
            //gvProduct.HeaderRow.TableSection = TableRowSection.TableHeader;

            //FillProductGridView();
            //FillProductViewByServerSide();
        }
    }

    #region FillRegularOrderGridView
    [System.Web.Services.WebMethod()]
    [System.Web.Script.Services.ScriptMethod()]
    public static string FillProductView()
    {
        BALProductMaster balProductMaster = new BALProductMaster();
        string jsonData = balProductMaster.SelectAllByDataTable();
        return jsonData;

        //BALProductMaster balProductMaster = new BALProductMaster();
        //DataTable dtProductMaster = balProductMaster.SelectAll();
        //if (dtProductMaster != null && dtProductMaster.Rows.Count > 0)
        //{
        //    gvProduct.DataSource = dtProductMaster;
        //    gvProduct.DataBind();
        //    gvProduct.UseAccessibleHeader = true;
        //    gvProduct.HeaderRow.TableSection = TableRowSection.TableHeader;
        //}
    }
    #endregion FillRegularOrderGridView

    #region FillProductViewByServerSide
    //[WebMethod(), ScriptMethod()]
    //public static string FillProductViewByServerSide()
    //{
    //    BALProductMaster balProductMaster = new BALProductMaster();
    //    string jsonData = balProductMaster.SelectAllDataByServerSide();
    //    return jsonData;
    //}
    #endregion FillProductViewByServerSide

    #region Show Data Server Side DataTable
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string SelectAllDataByServerSide(int draw, int start, int length, string order, string search)
    {
        int displayLength = length;
        int displayStart = start;
        int sortColumn = 0;
        string sortDir = "asc";
        string sSearch = search;
        int filterCount =0;

        var _order = JsonConvert.DeserializeObject<List<DataTableOrder>>(order);
        sortColumn = Convert.ToInt32(_order[0].Column);
        sortDir = _order[0].Dir;

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
                objCmd.Parameters.AddWithValue("@Search", sSearch);
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

        ProductMasterDataTable dataTableData = new ProductMasterDataTable();
        dataTableData.draw = draw;
        dataTableData.recordsTotal = filterCount;
        dataTableData.data = listProductMaster;
        dataTableData.recordsFiltered = filterCount;

        string json = JsonConvert.SerializeObject(dataTableData);
        return json;
    }
    #endregion Show Data Server Side DataTable

    #region gvProduct_RowCommand
    //protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    try
    //    {
    //        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
    //        {
    //            BALProductMaster balProductMaster = new BALProductMaster();
    //            if (balProductMaster.Delete(Convert.ToInt32(e.CommandArgument)))
    //            {
    //                FillProductGridView();
    //            }
    //            else
    //            {
    //                lblError.Text = balProductMaster.Message;
    //                lblError.ForeColor = Color.Red;
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblError.Text = ex.Message.ToString();
    //        lblError.ForeColor = Color.Red;
    //    }
    //}
    #endregion gvProduct_RowCommand

    #region Delete Record
    [System.Web.Services.WebMethod()]
    public void Delete(int ProductID)
    {
        BALProductMaster balProductMaster = new BALProductMaster();
        balProductMaster.Delete(ProductID);
    }
    #endregion Delete Record

}