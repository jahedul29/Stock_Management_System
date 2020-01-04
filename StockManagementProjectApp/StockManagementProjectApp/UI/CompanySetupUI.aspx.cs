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
    public partial class CompanySetupUI : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            companyListGridView.DataSource = companyManager.GetAllCompanies();      //Loading the GridView
            companyListGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {

            if (companyTextBox.Text != "")                                   //Restricting Inserting NULL value
            {
                Company company = new Company();
                company.CompanyName = companyTextBox.Text;
                outputLabel.Text = companyManager.SaveCompany(company);
                companyTextBox.Text = String.Empty;
                Response.Redirect("CompanySetupUI.aspx");
            }
            else
            {
                outputLabel.Text = "Enter a Valid Company Please...";
            }
        }
    }
}