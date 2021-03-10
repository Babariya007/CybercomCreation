using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContactDetailsPrectice
{
    public partial class ContactAddEdit : System.Web.UI.Page
    {
        #region PageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["ContactId"] != null)
                {
                    lblMessage.Text = "Edit Contact";
                    LoadControls(Convert.ToInt32(Request.QueryString["ContactId"]));
                }
                else
                {
                    lblMessage.Text = "Add New Contact";
                }
                FillDropDownListCountry();
                FillDropDownListContactCategory();
            }
            
        }
        #endregion PageLoad

        #region LoadControls
        private void LoadControls(Int32 ContactID)
        {
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactCS"].ConnectionString);
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Contact_SelectByPK";
            objCmd.Parameters.AddWithValue("@ContactID", ContactID);
            objConn.Open();

            using (SqlDataReader objSDR = objCmd.ExecuteReader())
            {
                while (objSDR.Read())
                {
                    if (!objSDR["ContactName"].Equals(DBNull.Value))
                    {
                        txtContactName.Text = objSDR["ContactName"].ToString();
                    }
                    if (!objSDR["Address"].Equals(DBNull.Value))
                    {
                        txtAddress.Text = objSDR["Address"].ToString();
                    }
                    if (!objSDR["Pincode"].Equals(DBNull.Value))
                    {
                        txtPincode.Text = objSDR["Pincode"].ToString();
                    }
                    if (!objSDR["Email"].Equals(DBNull.Value))
                    {
                        txtEmailAddress.Text = objSDR["Email"].ToString();
                    }
                    if (!objSDR["MobileNumber"].Equals(DBNull.Value))
                    {
                        txtMobileNo.Text = objSDR["MobileNumber"].ToString();
                    }
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountry.SelectedValue = objSDR["CountryID"].ToString();
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlState.SelectedValue = objSDR["StateID"].ToString();
                    }
                    if (!objSDR["CityID"].Equals(DBNull.Value))
                    {
                        ddlCity.SelectedValue = objSDR["CityID"].ToString();
                    }
                    if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                    {
                        ddlContactCategory.SelectedValue = objSDR["ContactCategoryID"].ToString();
                    }
                }
            }
            objConn.Close();
        }
        #endregion LoadControls

        #region DropdownList
        private void FillDropDownListCountry()
        {
            FillDropDownList("PR_Country_SelectForDropDownList", "CountryName", "CountryID", ddlCountry);
        }

        private void FillDropDownListContactCategory()
        {
            FillDropDownList("PR_ContactCategory_SelectForDropDownList", "ContactCategoryName", "ContactCategoryID", ddlContactCategory);
        }

        private void FillDropDownListState(Int32 CountryID)
        {
            SelectIndexFillDropdown("PR_State_SelectForDropDownList", "@CountryID", CountryID, "StateName", "StateID", ddlState);
        }

        private void FillDropDownListCity(Int32 StateID)
        {
            SelectIndexFillDropdown("PR_City_SelectForDropDownList", "@StateID", StateID, "CityName", "CityID", ddlCity);           
        }
        #endregion DropdownList

        #region FillDropDownListFunction
        private void FillDropDownList(string ProcedureName, string TextFild, string FildValue, DropDownList ddl)
        {
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactCS"].ConnectionString);
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = ProcedureName;
            objConn.Open();

            SqlDataReader objSDRCountry = objCmd.ExecuteReader();
            ddl.DataSource = objSDRCountry;
            ddl.DataTextField = TextFild;
            ddl.DataValueField = FildValue;
            ddl.DataBind();

            objConn.Close();
        }
        #endregion FillDropDownListFunction

        #region SelectIndexFillDropdown
        private void SelectIndexFillDropdown(string Procedure, string ParaID, int DDLValue, string TextFild, string FildValue, DropDownList ddl)
        {
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactCS"].ConnectionString);
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = Procedure;
            objCmd.Parameters.AddWithValue(ParaID, DDLValue);
            objConn.Open();

            SqlDataReader objSDRCountry = objCmd.ExecuteReader();
            ddl.DataSource = objSDRCountry;
            ddl.DataTextField = TextFild;
            ddl.DataValueField = FildValue;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Please Select", "-1"));

            objConn.Close();
        }
        #endregion SelectIndexFillDropdown

        #region Selected Index Change
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDropDownListState(Convert.ToInt32(ddlCountry.SelectedValue));
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDropDownListCity(Convert.ToInt32(ddlState.SelectedValue));
        }
        #endregion Selected Index Change

        #region SaveButton
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlString strContactName = SqlString.Null;
            SqlString strAddress = SqlString.Null;
            SqlString strPinCode = SqlString.Null;
            SqlString strEmail = SqlString.Null;
            SqlString strMobileNo = SqlString.Null;
            SqlInt32 strCityID = SqlInt32.Null;
            SqlInt32 strStateID = SqlInt32.Null;
            SqlInt32 strCountry = SqlInt32.Null;
            SqlInt32 strContactCategoryID = SqlInt32.Null;

            if (txtContactName.Text.Trim() != "")
                strContactName = txtContactName.Text.Trim();
            if (txtAddress.Text.Trim() != "")
                strAddress = txtAddress.Text.Trim();
            if (txtPincode.Text.Trim() != "")
                strPinCode = txtPincode.Text.Trim();
            if (txtEmailAddress.Text.Trim() != "")
                strEmail = txtEmailAddress.Text.Trim();
            if (txtMobileNo.Text.Trim() != "")
                strMobileNo = txtMobileNo.Text.Trim();
            if (ddlCountry.SelectedIndex > 0)
                strCountry = Convert.ToInt32(ddlCountry.SelectedValue);
            if (ddlState.SelectedIndex > 0)
                strStateID = Convert.ToInt32(ddlState.SelectedValue);
            if (ddlCity.SelectedIndex > 0)
                strCityID = Convert.ToInt32(ddlCity.SelectedValue);
            if (ddlContactCategory.SelectedIndex > 0)
                strContactCategoryID = Convert.ToInt32(ddlContactCategory.SelectedValue);

            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ContactCS"].ConnectionString);
            objConn.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.StoredProcedure;

            if (Request.QueryString["ContactId"] == null)
            {
                objCmd.CommandText = "PR_Contact_Insert";
                objCmd.Parameters.AddWithValue("@ContactName", strContactName);
                objCmd.Parameters.AddWithValue("@Address", strAddress);
                objCmd.Parameters.AddWithValue("@Pincode", strPinCode);
                objCmd.Parameters.AddWithValue("@Email", strEmail);
                objCmd.Parameters.AddWithValue("@CityID", strCityID);
                objCmd.Parameters.AddWithValue("@StateID", strStateID);
                objCmd.Parameters.AddWithValue("@CountryID", strCountry);
                objCmd.Parameters.AddWithValue("@MobileNumber", strMobileNo);
                objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategoryID);
            }
            else
            {
                objCmd.CommandText = "PR_Contact_UpdateByPK";
                objCmd.Parameters.AddWithValue("@ContactID", Request.QueryString["ContactId"]);
                objCmd.Parameters.AddWithValue("@ContactName", txtContactName.Text);
                objCmd.Parameters.AddWithValue("@Address", txtEmailAddress.Text);
                objCmd.Parameters.AddWithValue("@Pincode", txtPincode.Text);
                objCmd.Parameters.AddWithValue("@Email", txtEmailAddress.Text);
                objCmd.Parameters.AddWithValue("@CityID", ddlCity.SelectedValue);
                objCmd.Parameters.AddWithValue("@StateID", ddlState.SelectedValue);
                objCmd.Parameters.AddWithValue("@CountryID", ddlCountry.SelectedValue);
                objCmd.Parameters.AddWithValue("@MobileNumber", txtMobileNo.Text);
                objCmd.Parameters.AddWithValue("@ContactCategoryID", ddlContactCategory.SelectedValue);
            }

            objCmd.ExecuteNonQuery();

            if (Request.QueryString["ContactId"] == null)
            {
                lblMessage.Text = "Data Inserted Sussecfully...";
                lblMessage.ForeColor = Color.Green;
                txtContactName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtPincode.Text = string.Empty;
                txtMobileNo.Text = string.Empty;
                txtEmailAddress.Text = string.Empty;
                ddlCountry.SelectedIndex = 0;
                ddlState.SelectedIndex = 0;
                ddlCity.SelectedIndex = 0;
                ddlContactCategory.SelectedIndex = 0;
                txtContactName.Focus();
            }
            else
            {
                Response.Redirect("~/ContactList.aspx");
            }
        }
        #endregion SaveButton

    }
}