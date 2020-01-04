using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementProjectApp.BLL;

namespace StockManagementProjectApp.UI
{
    public partial class SearchAndViewUI : System.Web.UI.Page
    {
        ItemManager itemManager = new ItemManager();
        CompanyManager companyManager = new CompanyManager();
        CatagoryManager catagoryManager = new CatagoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                companyDropDownList.DataSource = companyManager.GetAllCompanies();
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, "Select Company");

                catagoryDropDownList.DataSource = catagoryManager.GetAllCatagories();
                catagoryDropDownList.DataValueField = "Id";
                catagoryDropDownList.DataTextField = "CatagoryName";
                catagoryDropDownList.DataBind();
                catagoryDropDownList.Items.Insert(0, "Select Catagory");
            }
            
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            outputLabel.Text = String.Empty;
            searchAndViewGridView.DataSource = null;
            searchAndViewGridView.DataBind();

            if (companyDropDownList.SelectedIndex !=0 && catagoryDropDownList.SelectedIndex !=0)
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                int catagoryId = Convert.ToInt32(catagoryDropDownList.SelectedValue);
                if (itemManager.GetItemsByCompanyIdAndCatagoryId(companyId, catagoryId) != null)
                {
                    searchAndViewGridView.DataSource = itemManager.GetItemsByCompanyIdAndCatagoryId(companyId, catagoryId);
                    searchAndViewGridView.DataBind();

                    companyDropDownList.SelectedIndex = 0;
                    catagoryDropDownList.SelectedIndex = 0;
                }
                else
                {
                    outputLabel.Text = "Item from this Company and Catagory not present";
                }
            }
            else if (companyDropDownList.SelectedIndex != 0)
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                searchAndViewGridView.DataSource = itemManager.GetItemsByCompanyId(companyId);
                searchAndViewGridView.DataBind();

                companyDropDownList.SelectedIndex = 0;
                catagoryDropDownList.SelectedIndex = 0;
            }
            else if (catagoryDropDownList.SelectedIndex != 0)
            {
                int catagoryId = Convert.ToInt32(catagoryDropDownList.SelectedValue);
                searchAndViewGridView.DataSource = itemManager.GetItemsByCatagoryId(catagoryId);
                searchAndViewGridView.DataBind();

                companyDropDownList.SelectedIndex = 0;
                catagoryDropDownList.SelectedIndex = 0;
            }
            else
            {
                outputLabel.Text = "Please Select at least One Section";
            }
        }

    }
}