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
    public partial class StockIn : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        ItemManager itemManager = new ItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TaskOnFirstLoad();
            }           
        }

        private void TaskOnFirstLoad()
        {
            companyDropDownList.DataSource = companyManager.GetAllCompanies();
            companyDropDownList.DataValueField = "Id";
            companyDropDownList.DataTextField = "CompanyName";
            companyDropDownList.DataBind();
            companyDropDownList.Items.Insert(0, "Select Company");
            

            itemDropDownList.Enabled = false;
            stockInTextbox.Enabled = false;
        }
        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (companyDropDownList.SelectedIndex == 0)
            {
                itemDropDownList.Enabled = false;
                stockInTextbox.Enabled = false;
            }
            else
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                itemDropDownList.Enabled = true;
                itemDropDownList.DataSource = itemManager.GetItemsByCompanyId(companyId);
                itemDropDownList.DataValueField = "ItemId";
                itemDropDownList.DataTextField = "ItemName";
                itemDropDownList.DataBind();
                itemDropDownList.Items.Insert(0, "Select Item");
                

            }
        }

        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemDropDownList.SelectedIndex!=0)
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                int itemId = Convert.ToInt32(itemDropDownList.SelectedValue);
                stockInTextbox.Enabled = true;
                ItemViewModel item = itemManager.GetItemByItemId(itemId);
                availableQuantityHiddenField.Value = item.AvailableQuantity.ToString();
                reorderLavelTextBox.Text = item.ReorderLavel.ToString();
                availableQuantityTextBox.Text = item.AvailableQuantity.ToString();
            }
            else
            {
                itemDropDownList.Enabled = false;
                stockInTextbox.Enabled = false;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            int availableQuantity = Convert.ToInt32(availableQuantityHiddenField.Value);
            int itemId = Convert.ToInt32(itemDropDownList.SelectedValue);
            int stockQuantity = Convert.ToInt32(stockInTextbox.Text);
            if (stockInTextbox.Text != "" & stockQuantity !=0)
            {
                int totalQuantity = availableQuantity + stockQuantity;
                string message = itemManager.StockInItem(totalQuantity, itemId);
                outputLabel.Text = message;
                reorderLavelTextBox.Text = String.Empty;
                availableQuantityTextBox.Text = String.Empty;
                itemDropDownList.SelectedIndex = 0;
                stockInTextbox.Text = String.Empty;
                TaskOnFirstLoad();
            }
            else
            {
                outputLabel.Text = "Enter Valid stock";
            }
            
        }
    }
}