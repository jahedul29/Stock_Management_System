using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementProjectApp.BLL;
using StockManagementProjectApp.DAL.Modals;

namespace StockManagementProjectApp.UI
{
    public partial class ItemSetupUI : System.Web.UI.Page
    {
        CatagoryManager catagoryManager = new CatagoryManager();
        CompanyManager companyManager = new CompanyManager();
        ItemManager itemManager = new ItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                catagoryDropDownList.DataSource = catagoryManager.GetAllCatagories();

                catagoryDropDownList.DataValueField = "Id";
                catagoryDropDownList.DataTextField = "CatagoryName";
                catagoryDropDownList.DataBind();
                catagoryDropDownList.Items.Insert(0, "Select Catagory");

                companyDropDownList.DataSource = companyManager.GetAllCompanies();
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, "Select Company");
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            int catagorySelect = catagoryDropDownList.SelectedIndex;
            int companySelect = companyDropDownList.SelectedIndex;
            if (catagorySelect != 0 && companySelect!=0 && itemNameTextBox.Text!="")
            {
                Item item = new Item();
                item.ItemName = itemNameTextBox.Text;
                item.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                item.CatagoryId = Convert.ToInt32(catagoryDropDownList.SelectedValue);
                outputLabel.Text = itemManager.SaveItem(item);
                itemNameTextBox.Text = String.Empty;
                reorderLabelTextbox.Text = String.Empty;
                catagoryDropDownList.SelectedIndex = 0;
                companyDropDownList.SelectedIndex = 0;
            }
            else
            {
                outputLabel.Text = "Fill all field without Reorder lavel..";
            }
            
        }
    }
}