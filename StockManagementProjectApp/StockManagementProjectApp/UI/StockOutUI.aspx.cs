using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementProjectApp.BLL;
using StockManagementProjectApp.DAL.Modals.ViewModel;

namespace StockManagementProjectApp.UI
{
    public partial class StockOutUI : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        ItemManager itemManager = new ItemManager();
        List<ItemViewModel> itemViewModelList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                companyDropDownList.DataSource = companyManager.GetAllCompanies();
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, "Select Company");
                itemDropDownList.Items.Insert(0,"Select Item");
                itemDropDownList.Enabled = false;
                stockOutTextBox.Enabled = false;

                itemViewModelList = new List<ItemViewModel>();
            }
            
        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (companyDropDownList.SelectedIndex !=0)
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                itemDropDownList.Enabled = true;

                itemDropDownList.DataSource = itemManager.GetItemsByCompanyId(companyId);
                itemDropDownList.DataValueField = "ItemId";
                itemDropDownList.DataTextField = "ItemName";
                itemDropDownList.DataBind();
                itemDropDownList.Items.Insert(0, "Select Item");
            }
            else
            {
                itemDropDownList.SelectedIndex = 0;
                itemDropDownList.Enabled = false;
                stockOutTextBox.Enabled = false;
            }
        }

        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemDropDownList.SelectedIndex != 0)
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                int itemId = Convert.ToInt32(itemDropDownList.SelectedValue);
                ItemViewModel itemViewModel = itemManager.GetItemByItemId(itemId);

                stockOutTextBox.Enabled = true;
                reorderLavelTextBox.Text = itemViewModel.ReorderLavel.ToString();
                availableQuantityTextBox.Text = itemViewModel.AvailableQuantity.ToString();
                
            }
            else
            {
                stockOutTextBox.Enabled = false;
                reorderLavelTextBox.Text = "";
                availableQuantityTextBox.Text ="";
            }

        }

        private int availableWithStockOut = 0;
        protected void addButton_Click(object sender, EventArgs e)
        {
            int itemId = Convert.ToInt32(Convert.ToInt32(itemDropDownList.SelectedValue));

            ItemViewModel itemViewModel = itemManager.GetItemByItemId(itemId);
            

            //availableWithStockOut -= itemViewModel.AvailableQuantity;
            itemViewModelList.Add(itemViewModel);

            stockOutGridView.DataSource = itemViewModelList;
            stockOutGridView.DataBind();
        }
    }
}