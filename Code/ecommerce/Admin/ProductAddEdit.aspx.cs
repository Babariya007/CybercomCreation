using eCommerce;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ProductAddEdit : System.Web.UI.Page
{
    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtProductName.Focus();

            if (Request.QueryString["ProductID"] != null)
            {
                LoadControls(Convert.ToInt32(Request.QueryString["ProductID"]));
                lblPageHeader.Text = "Edit Product Details";
                btnSave.Text = "Update";
            }
            else
            {
                lblPageHeader.Text = "Add New Product";
            }
        }
    }
    #endregion Page_Load

    #region LoadControls
    private void LoadControls(SqlInt32 ProductID)
    {
        ENTProductMaster entProductMaster = new ENTProductMaster();
        DALProductMaster balProductMaster = new DALProductMaster();

        entProductMaster = balProductMaster.SelectByPK(ProductID);

        if (!entProductMaster.ProductName.IsNull)
            txtProductName.Text = entProductMaster.ProductName.Value.ToString();

        if (!entProductMaster.ProductQuantity.IsNull)
            txtQuntity.Text = entProductMaster.ProductQuantity.Value.ToString();

        if (!entProductMaster.ProductDetails.IsNull)
            txtProductDetails.Text = entProductMaster.ProductDetails.Value.ToString();

        if (!entProductMaster.ProductPrice.IsNull)
            txtProductPrice.Text = entProductMaster.ProductPrice.Value.ToString();

        if (!entProductMaster.ProductImage.IsNull)
            FuUpload.SaveAs(Server.MapPath(entProductMaster.ProductImage.Value.ToString()));
    }

    #endregion LoadControls

    #region Save Button
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            #region Server Side Validation

            String strError = String.Empty;

            if (txtProductName.Text.Trim() == String.Empty)
                strError += "- Enter Product Name<br />";

            if (txtQuntity.Text.Trim() == String.Empty)
                strError += "- Enter Quantity<br />";

            if (txtProductDetails.Text.Trim() == String.Empty)
                strError += "- Enter Product Details<br />";

            if (txtProductPrice.Text.Trim() == String.Empty)
                strError += "- Enter Product Price<br />";

            #endregion Server Side Validation

            ENTProductMaster entProductMaster = new ENTProductMaster();
            BALProductMaster balProductMaster = new BALProductMaster();

            #region Gather Data

            if (txtProductName.Text.Trim() != String.Empty)
                entProductMaster.ProductName = Convert.ToString(txtProductName.Text.Trim());

            if (txtQuntity.Text.Trim() != String.Empty)
                entProductMaster.ProductQuantity = Convert.ToInt32(txtQuntity.Text.Trim());

            if (txtProductDetails.Text.Trim() != String.Empty)
                entProductMaster.ProductDetails = Convert.ToString(txtProductDetails.Text.Trim());

            if (txtProductPrice.Text.Trim() != String.Empty)
                entProductMaster.ProductPrice = Convert.ToDecimal(txtProductPrice.Text.Trim());

            if (FuUpload.HasFile)
            {
                string fileExt = System.IO.Path.GetExtension(FuUpload.FileName);

                if (fileExt.ToLower() == ".jpeg" || fileExt.ToLower() == ".jpg" || fileExt.ToLower() == ".png")
                {
                    string strFilePath = "~/Content/ProductImage/";
                    FuUpload.SaveAs(Server.MapPath(strFilePath + FuUpload.FileName));
                    entProductMaster.ProductImage = Convert.ToString(strFilePath + FuUpload.FileName);
                }
                else
                {
                    rfvFileUpload.Text = "Only Upload .jpg .jpeg and .png";
                }
            }

            if (Request.QueryString["ProductID"] == null)
            {
                balProductMaster.Insert(entProductMaster);
                lblMessage.Text = "Data Inserted Successfully...";
                lblMessage.ForeColor = Color.Green;
                ClearControls();
            }
            else
            {
                entProductMaster.ProductID = Convert.ToInt32(Request.QueryString["ProductID"]);
                balProductMaster.Update(entProductMaster);
                Response.Redirect("~/Admin/ProductList.aspx");
            }

            #endregion Gather Data

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message.ToString();
            lblError.ForeColor = Color.Red;
        }
    }
    #endregion Save Button

    #region ClearControls
    private void ClearControls()
    {
        txtProductName.Text = String.Empty;
        txtQuntity.Text = String.Empty;
        txtProductDetails.Text = String.Empty;
        txtProductPrice.Text = String.Empty;
        FuUpload.Attributes.Clear();
        txtProductName.Focus();
    }
    #endregion ClearControls
}