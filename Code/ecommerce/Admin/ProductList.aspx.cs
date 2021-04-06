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
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ProductList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //DataTable dummy = new DataTable();
            //dummy.Columns.Add("ProductID");
            //dummy.Columns.Add("ProductName");
            //dummy.Columns.Add("ProductQuantity");
            //dummy.Columns.Add("ProductDetails");
            //dummy.Columns.Add("ProductPrice");
            //dummy.Columns.Add("ProductImage");

            //dummy.Rows.Add();
            //gvProduct.DataSource = dummy;
            //gvProduct.DataBind();

            //gvProduct.UseAccessibleHeader = true;
            //gvProduct.HeaderRow.TableSection = TableRowSection.TableHeader;

            //FillProductGridView();
        }
    }

    #region FillRegularOrderGridView

    [System.Web.Services.WebMethod()]
    [System.Web.Script.Services.ScriptMethod()]
    public static string FillProductGridView()
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
        string jsonData = JsonConvert.SerializeObject(listProductMaster);
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